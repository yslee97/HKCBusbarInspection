﻿using MvCamCtrl.NET;
using MvUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using OpenCvSharp;
using MvFGCtrlC.NET;
using static HKCBusbarInspection.Schemas.신호제어;
using DevExpress.Utils.CodedUISupport;

namespace HKCBusbarInspection.Schemas
{
    public class 그랩제어 : Dictionary<카메라구분, 그랩장치>
    {
        //private String 셔틀번호변수이름 = "셔틀번호";
        public static List<카메라구분> 대상카메라 = new List<카메라구분>() { 카메라구분.Cam01, 카메라구분.Cam02, 카메라구분.Cam03, 카메라구분.Cam04, 카메라구분.Cam05 };
        public static List<셔틀위치> 대상셔틀 = new List<셔틀위치>() { 셔틀위치.Shuttle01, 셔틀위치.Shuttle02, 셔틀위치.Shuttle03 };

        public delegate void 그랩완료대리자(그랩장치 장치);
        public event 그랩완료대리자 그랩완료보고;

        [JsonIgnore]
        public HikeCxp 상부검사카메라 = null;
        [JsonIgnore]
        public HikeGigE 측면검사카메라 = null;
        [JsonIgnore]
        public HikeGigE L부검사카메라 = null;
        [JsonIgnore]
        public HikeGigE 하부검사카메라 = null;
        [JsonIgnore]
        public HikeGigE 트레이검사카메라 = null;

        [JsonIgnore]
        private const string 로그영역 = "Camera";
        [JsonIgnore]
        private string 저장파일 => Path.Combine(Global.환경설정.기본경로, "Cameras.json");
        [JsonIgnore]
        public Boolean 정상여부 => !this.Values.Any(e => !e.상태);

        public Boolean Init()
        {
            this.상부검사카메라 = new HikeCxp() { 구분 = 카메라구분.Cam01, 코드 = "DA3152184" };
            this.측면검사카메라 = new HikeGigE() { 구분 = 카메라구분.Cam02, 코드 = "DA3152197" };
            this.L부검사카메라 = new HikeGigE() { 구분 = 카메라구분.Cam03, 코드 = "DA0754921" };
            this.하부검사카메라 = new HikeGigE() { 구분 = 카메라구분.Cam04, 코드 = "DA3151054" };
            this.트레이검사카메라 = new HikeGigE() { 구분 = 카메라구분.Cam05, 코드 = "DA2144005" };

            this.Add(카메라구분.Cam01, this.상부검사카메라);
            this.Add(카메라구분.Cam02, this.측면검사카메라);
            this.Add(카메라구분.Cam03, this.L부검사카메라);
            this.Add(카메라구분.Cam04, this.하부검사카메라);
            this.Add(카메라구분.Cam05, this.트레이검사카메라);

            // 카메라 설정 저장정보 로드
            그랩장치 정보;
            List<그랩장치> 자료 = Load();
            if (자료 != null)
            {
                foreach (그랩장치 설정 in 자료)
                {
                    정보 = this.GetItem(설정.구분);
                    if (정보 == null) continue;
                    정보.Set(설정);
                }
            }
            if (Global.환경설정.동작구분 != 동작구분.Live) return true;

            if (!GIGE카메라연결()) return false;
            if (!CXP카메라연결()) return false;

            Debug.WriteLine($"카메라 갯수: {this.Count}");
            GC.Collect();
            return true;
        }

        private Boolean CXP카메라연결()
        {
            MvFGCtrlC.NET.CSystem m_cSystem = new MvFGCtrlC.NET.CSystem();
            bool bChanged = false;
            UInt32 nDeviceNum = 0;
            MV_FG_DEVICE_INFO stDeviceInfo = new MV_FG_DEVICE_INFO();

            //오류처리 해줘야함.
            int nRet = m_cSystem.UpdateInterfaceList(CParamDefine.MV_FG_CXP_INTERFACE, ref bChanged);

            nRet = m_cSystem.OpenInterface(Convert.ToUInt32(0), out CInterface m_cInterface);

            if (nRet != 0) return false;

            nRet = m_cInterface.UpdateDeviceList(ref bChanged);

            nRet = m_cInterface.GetNumDevices(ref nDeviceNum);

            for (UInt32 lop = 0; lop < nDeviceNum; lop++)
            {
                nRet = m_cInterface.GetDeviceInfo(lop, ref stDeviceInfo);
                if (stDeviceInfo.nDevType == CParamDefine.MV_FG_CXP_DEVICE)
                {
                    MV_CXP_DEVICE_INFO stCxpDevInfo = (MV_CXP_DEVICE_INFO)CAdditional.ByteToStruct(
                                   stDeviceInfo.DevInfo.stCXPDevInfo, typeof(MV_CXP_DEVICE_INFO));

                    if (!(this.GetItem(stCxpDevInfo.chSerialNumber) is HikeCxp gige)) continue;
                    gige.Init(m_cInterface, stCxpDevInfo);
                }
            }

            return true;
        }

        private Boolean GIGE카메라연결()
        {
            List<CCameraInfo> 카메라들 = new List<CCameraInfo>();

            Int32 nRet = MvCamCtrl.NET.CSystem.EnumDevices(MvCamCtrl.NET.CSystem.MV_GIGE_DEVICE, ref 카메라들);

            if (!Validate("Enumerate devices fail!", nRet, true)) return false;

            for (Int32 lop = 0; lop < 카메라들.Count; lop++)
            {
                CGigECameraInfo gigeInfo = 카메라들[lop] as CGigECameraInfo;
                if (!(this.GetItem(gigeInfo.chSerialNumber) is HikeGigE gige)) continue;
                gige.Init(gigeInfo);
            }
            return true;
        }

        private List<그랩장치> Load()
        {
            if (!File.Exists(this.저장파일)) return null;
            return JsonConvert.DeserializeObject<List<그랩장치>>(File.ReadAllText(this.저장파일), Utils.JsonSetting());
        }

        public void Save()
        {
            if (!Utils.WriteAllText(저장파일, JsonConvert.SerializeObject(this.Values, Utils.JsonSetting())))
                Global.오류로그(로그영역, "카메라 설정 저장", "카메라 설정 저장에 실패하였습니다.", true);
        }

        public void Close()
        {
            if (Global.환경설정.동작구분 != 동작구분.Live) return;
            foreach (그랩장치 장치 in this.Values)
                장치?.Close();
        }
        public void Active(카메라구분 구분) => this.GetItem(구분)?.Active();

        public 그랩장치 GetItem(카메라구분 구분)
        {
            if (this.ContainsKey(구분)) return this[구분];
            return null;
        }
        private 그랩장치 GetItem(String serial) => this.Values.Where(e => e.코드 == serial).FirstOrDefault();

        private Boolean 검사자료생성(Int32 이미지개수)
        {
            try
            {
                Int32 하부검사번호 = 0;
                if (이미지개수 == 1)
                    하부검사번호 = Global.신호제어.하부01인덱스;
                if (이미지개수 == 2)
                    하부검사번호 = Global.신호제어.하부02인덱스;
                if (이미지개수 == 3)
                    하부검사번호 = Global.신호제어.하부03인덱스;

                Debug.WriteLine($"검사자료생성시 인덱스번호 : [ {하부검사번호} ]");

                if (하부검사번호 == 0) return false;

                //Global.신호제어.인덱스버퍼[(정보주소)이미지개수];
                Global.모델자료.선택모델.검사시작(하부검사번호);
                Global.검사자료.검사시작(하부검사번호, true);
                return true;
            }
            catch(Exception ex)
            {
                Global.오류로그("검사자료생성", "검사자료생성오류", $"{ex.Message}", true);
                return false;   
            }
        }

        public void 그랩완료(그랩장치 장치)
        {
            if (Global.장치상태.자동수동)
            {
                Mat 검사이미지 = 장치.MatImage();
                Mat 표면이미지 = 장치.SurFaceImage();

                if (장치.구분 == 카메라구분.Cam05 && 장치.트레이검사중 == true)
                {//트레이검사
                    장치.TrayMatImage = 검사이미지;
                    장치.트레이검사중 = false;

                    Global.VM제어.GetItem(장치.구분).Run(장치.TrayMatImage, null, null, null);
                    Global.사진자료.SaveImage(장치, DateTime.Now, 장치.TrayMatImage, false);

                    Dictionary<String, String> 트레이검사결과 = Global.VM제어.GetItem(장치.구분).트레이검사결과;

                    //PLC 결과 전달
                    int nResult = 0;

                    //유무결과전달
                    String 유무결과;
                    트레이검사결과.TryGetValue("유무결과", out 유무결과);
                    nResult = int.Parse(유무결과);
                    Common.DebugWriteLine("트레이검사완료", 로그구분.정보, $"유무 : {nResult}");
                    //임시 로직 개선 후 실측값 적용예정
                    Global.신호제어.트레이유무결과 = 1;


                    //방향결과전달
                    String 방향결과;
                    트레이검사결과.TryGetValue("방향결과", out 방향결과);
                    if (방향결과 == "Forward")
                        nResult = 1;
                    else if (방향결과 == "Reverse")
                        nResult = 2;
                    else
                        nResult = -1;
                    Global.신호제어.트레이방향결과= nResult;
                    Common.DebugWriteLine("트레이검사완료", 로그구분.정보, $"방향 : {nResult}");

                    //모델결과전달
                    String 모델결과;
                    Int32 n모델결과;

                    Int32 모델번호 = Global.신호제어.모델번호;

                    트레이검사결과.TryGetValue("모델결과", out 모델결과);
                    if (모델결과 == Utils.GetDescription(모델구분.POS_3P))
                        n모델결과 = Convert.ToInt32(모델구분.POS_3P);    
                    else if (모델결과 == Utils.GetDescription(모델구분.NEG_3P))
                        n모델결과 = Convert.ToInt32(모델구분.NEG_3P);
                    else
                        n모델결과 = -1;

                    if (n모델결과 == 모델번호)
                        nResult = 1;
                    else
                        nResult = 2;
                    Global.신호제어.트레이모델결과 = nResult;
                    Common.DebugWriteLine("트레이검사완료", 로그구분.정보, $"모델 : {nResult}");


                    Common.DebugWriteLine("트레이검사완료", 로그구분.정보, $"검사 결과 전송 / 유무 : {유무결과}, 방향 : {방향결과}, 모델 : {모델결과}");

                    트레이검사결과.Clear();

                }
                else
                {//셔틀 검사
                    if (장치.구분 == 카메라구분.Cam01 && 장치.표면검사중)
                    {
                        장치.SurFaceMatImageList.Add(검사이미지);

                        장치.대비적용(Global.신호제어.치수검사Gain);
                    }
                    else
                    {
                        장치.MatImageList.Add(검사이미지);
                        if(장치.구분 == 카메라구분.Cam01)
                            장치.대비적용(Global.신호제어.표면검사Gain);
                    }

                    Int32 이미지개수 = 장치.표면검사중 ? 장치.SurFaceMatImageList.Count : 장치.MatImageList.Count;

                    if (장치.구분 == 카메라구분.Cam04)
                        if (!검사자료생성(이미지개수)) { Global.오류로그("그랩완료", "검사번호없음", $"[{장치.구분} - {이미지개수}] 해당 검사가 없습니다.", true); return; }

                    Int32 검사번호 = Global.신호제어.촬영위치번호(장치.구분, 이미지개수, 장치.표면검사중);
                    검사결과 검사 = Global.검사자료.검사항목찾기(검사번호, true);
                    if (검사 == null) { Global.오류로그("그랩완료", "검사번호없음", $"Index[{검사번호}] 해당 검사가 없습니다.", true); return; }

                    //검사시작전에 완료신호 전송해주기.
                    장치.검사중 = false;
                    완료신호전송(장치, 이미지개수);

                    if (장치.표면검사중 || 장치.구분 == 카메라구분.Cam04)
                    {
                        if (장치.구분 == 카메라구분.Cam04) //하부표면
                        {
                            Global.VM제어.GetItem(장치.구분).Run(표면이미지, null, null, 검사);
                            Global.사진자료.SaveImage(장치, 검사, 표면이미지, true);
                        }
                        else //상부표면
                        {
                            Global.VM제어.GetItem(Flow구분.상부표면).Run(표면이미지, null, null, 검사);
                            Global.사진자료.SaveImage(장치, 검사, 표면이미지, true);
                        }
                    }
                    else
                    {
                        Global.VM제어.GetItem(장치.구분).Run(검사이미지, null, null, 검사);
                        Global.사진자료.SaveImage(장치, 검사, 검사이미지, false);
                    }
                }

                이미지초기화(장치);
            }
            else
            {
                //Global.VM제어.글로벌변수제어.SetValue(셔틀번호변수이름, Utils.GetDescription(Global.환경설정.수동검사셔틀위치));
                Global.VM제어.GetItem(장치.구분).Run(장치.MatImage(), null, null, Global.검사자료.수동검사);
                //Global.VM제어.GetItem(Flow구분.상부표면).Run(장치.MatImage(), null, null, Global.검사자료.수동검사);
                검사결과 검사 = Global.검사자료.검사결과계산(Global.검사자료.수동검사.검사코드, false);
                Global.사진자료.SaveImage(장치, 검사);
                Global.검사자료.수동검사결과(장치.구분, 검사);
            }
            this.그랩완료보고?.Invoke(장치);
        }

        private void 이미지초기화(그랩장치 장치)
        {
            if (장치.MatImageList.Count == 3)
            {
                Common.DebugWriteLine(로그영역, 로그구분.정보, $"[{장치.구분}] => 치수 {장치.MatImageList.Count} 개 이미지 획득 완료 및 조명 Off");
                //장치.TurnOff();
                if (장치.구분 == 카메라구분.Cam04) Global.조명제어.TurnOff(사용구분.하부표면검사);
                장치.MatImageList.Clear();
            }
            if (장치.SurFaceMatImageList.Count == 3)
            {
                Common.DebugWriteLine(로그영역, 로그구분.정보, $"[{장치.구분}] => 표면 {장치.SurFaceMatImageList.Count} 개 이미지 획득 완료 및 조명 Off");
                //장치.TurnOff();
                Global.조명제어.TurnOff(사용구분.상부치수검사);
                Global.조명제어.TurnOff(사용구분.상부표면검사);
                장치.SurFaceMatImageList.Clear();
            }
            if(장치.TrayMatImage != null)
            {
                장치.TrayMatImage.Dispose();
            }
        }

        private void 완료신호전송(그랩장치 장치, Int32 순서)
        {
            if (장치.구분 == 카메라구분.Cam04)
            {
                if (순서 == 1) Global.신호제어.하부01촬영완료신호 = true;
                else if (순서 == 2) Global.신호제어.하부02촬영완료신호 = true;
                else if (순서 == 3) Global.신호제어.하부03촬영완료신호 = true;
            }
            else
            {
                if (장치.표면검사중)
                {
                    if (순서 == 1)
                    {
                        Common.DebugWriteLine(로그영역, 로그구분.정보, $"[셔틀01표면촬영완료신호] => true");
                        Global.신호제어.셔틀01표면촬영완료신호 = true;
                    }
                    else if (순서 == 2)
                    {
                        Common.DebugWriteLine(로그영역, 로그구분.정보, $"[셔틀02표면촬영완료신호] => true");
                        Global.신호제어.셔틀02표면촬영완료신호 = true;
                    }
                    else if (순서 == 3)
                    {
                        Common.DebugWriteLine(로그영역, 로그구분.정보, $"[셔틀03표면촬영완료신호] => true");
                        Global.신호제어.셔틀03표면촬영완료신호 = true;
                    }
                }
                else
                {
                    if (!Global.그랩제어.GetItem(카메라구분.Cam01).검사중 && !Global.그랩제어.GetItem(카메라구분.Cam02).검사중 && !Global.그랩제어.GetItem(카메라구분.Cam03).검사중)
                    {
                        if (순서 == 1)
                        {
                            Common.DebugWriteLine(로그영역, 로그구분.정보, $"[셔틀01치수촬영완료신호] => true");
                            Global.신호제어.셔틀01치수촬영완료신호 = true;
                        }
                        else if (순서 == 2)
                        {
                            Common.DebugWriteLine(로그영역, 로그구분.정보, $"[셔틀02치수촬영완료신호] => true");
                            Global.신호제어.셔틀02치수촬영완료신호 = true;
                        }
                        else if (순서 == 3)
                        {
                            Common.DebugWriteLine(로그영역, 로그구분.정보, $"[셔틀03치수촬영완료신호] => true");
                            Global.신호제어.셔틀03치수촬영완료신호 = true;
                        }
                    }
                }
            }
        }


        #region 오류메세지
        public static Boolean Validate(String message, Int32 errorNum, Boolean show)
        {
            if (errorNum == CErrorDefine.MV_OK) return true;

            String errorMsg = String.Empty;
            switch (errorNum)
            {
                case CErrorDefine.MV_E_HANDLE: errorMsg = "Error or invalid handle"; break;
                case CErrorDefine.MV_E_SUPPORT: errorMsg = "Not supported function"; break;
                case CErrorDefine.MV_E_BUFOVER: errorMsg = "Cache is full"; break;
                case CErrorDefine.MV_E_CALLORDER: errorMsg = "Function calling order error"; break;
                case CErrorDefine.MV_E_PARAMETER: errorMsg = "Incorrect parameter"; break;
                case CErrorDefine.MV_E_RESOURCE: errorMsg = "Applying resource failed"; break;
                case CErrorDefine.MV_E_NODATA: errorMsg = "No data"; break;
                case CErrorDefine.MV_E_PRECONDITION: errorMsg = "Precondition error, or running environment changed"; break;
                case CErrorDefine.MV_E_VERSION: errorMsg = "Version mismatches"; break;
                case CErrorDefine.MV_E_NOENOUGH_BUF: errorMsg = "Insufficient memory"; break;
                case CErrorDefine.MV_E_UNKNOW: errorMsg = "Unknown error"; break;
                case CErrorDefine.MV_E_GC_GENERIC: errorMsg = "General error"; break;
                case CErrorDefine.MV_E_GC_ACCESS: errorMsg = "Node accessing condition error"; break;
                case CErrorDefine.MV_E_ACCESS_DENIED: errorMsg = "No permission"; break;
                case CErrorDefine.MV_E_BUSY: errorMsg = "Device is busy, or network disconnected"; break;
                case CErrorDefine.MV_E_NETER: errorMsg = "Network error"; break;
                default: errorMsg = "Unknown error"; break;
            }

            Common.DebugWriteLine("Camera", 로그구분.오류, $"[{errorNum}] {message} {errorMsg}");
            Global.오류로그("Camera", "Error", $"[{errorNum}] {message} {errorMsg}", show);
            return false;
        }

        public static Boolean ValidateMVFG(String message, Int32 errorNum, Boolean show)
        {
            if (errorNum == CErrorCode.MV_FG_SUCCESS) return true;

            String errorMsg = String.Empty;
            switch (errorNum)
            {
                case CErrorCode.MV_FG_ERR_ERROR: errorMsg = "Unknown error"; break;
                case CErrorCode.MV_FG_ERR_NOT_INITIALIZED: errorMsg = "Not initialized"; break;
                case CErrorCode.MV_FG_ERR_NOT_IMPLEMENTED: errorMsg = "Not implemented"; break;
                case CErrorCode.MV_FG_ERR_RESOURCE_IN_USE: errorMsg = "Resource in use"; break;
                case CErrorCode.MV_FG_ERR_ACCESS_DENIED: errorMsg = "Access denied"; break;
                case CErrorCode.MV_FG_ERR_INVALID_HANDLE: errorMsg = "Invalid handle"; break;
                case CErrorCode.MV_FG_ERR_INVALID_ID: errorMsg = "Invalid ID"; break;
                case CErrorCode.MV_FG_ERR_NO_DATA: errorMsg = "No data"; break;
                case CErrorCode.MV_FG_ERR_INVALID_PARAMETER: errorMsg = "Invalid parameter"; break;
                case CErrorCode.MV_FG_ERR_IO: errorMsg = "IO error"; break;
                case CErrorCode.MV_FG_ERR_TIMEOUT: errorMsg = "Timeout"; break;
                case CErrorCode.MV_FG_ERR_ABORT: errorMsg = "Operation aborted"; break;
                case CErrorCode.MV_FG_ERR_INVALID_BUFFER: errorMsg = "Invalid buffer"; break;
                case CErrorCode.MV_FG_ERR_NOT_AVAILABLE: errorMsg = "Not available"; break;
                case CErrorCode.MV_FG_ERR_INVALID_ADDRESS: errorMsg = "Invalid address"; break;
                case CErrorCode.MV_FG_ERR_BUFFER_TOO_SMALL: errorMsg = "Buffer too small"; break;
                case CErrorCode.MV_FG_ERR_INVALID_INDEX: errorMsg = "Invalid index"; break;
                case CErrorCode.MV_FG_ERR_PARSING_CHUNK_DATA: errorMsg = "Parsing chunk data failed"; break;
                case CErrorCode.MV_FG_ERR_INVALID_VALUE: errorMsg = "Invalid value"; break;
                case CErrorCode.MV_FG_ERR_RESOURCE_EXHAUSTED: errorMsg = "Resource exhausted"; break;
                case CErrorCode.MV_FG_ERR_OUT_OF_MEMORY: errorMsg = "Out of memory"; break;
                case CErrorCode.MV_FG_ERR_BUSY: errorMsg = "Device busy"; break;
                case CErrorCode.MV_FG_ERR_LOADLIBRARY: errorMsg = "Load library failed"; break;
                case CErrorCode.MV_FG_ERR_CALLORDER: errorMsg = "Function call order error"; break;
                case CErrorCode.MV_FG_ERR_GC_GENERIC: errorMsg = "Generic error"; break;
                case CErrorCode.MV_FG_ERR_GC_ARGUMENT: errorMsg = "Invalid argument"; break;
                case CErrorCode.MV_FG_ERR_GC_RANGE: errorMsg = "Argument out of range"; break;
                case CErrorCode.MV_FG_ERR_GC_PROPERTY: errorMsg = "Property error"; break;
                case CErrorCode.MV_FG_ERR_GC_RUNTIME: errorMsg = "Runtime error"; break;
                case CErrorCode.MV_FG_ERR_GC_LOGICAL: errorMsg = "Logical error"; break;
                case CErrorCode.MV_FG_ERR_GC_ACCESS: errorMsg = "Access error"; break;
                case CErrorCode.MV_FG_ERR_GC_TIMEOUT: errorMsg = "Timeout error"; break;
                case CErrorCode.MV_FG_ERR_GC_DYNAMICCAST: errorMsg = "Dynamic cast error"; break;
                case CErrorCode.MV_FG_ERR_GC_UNKNOW: errorMsg = "Unknown error"; break;
                case CErrorCode.MV_FG_ERR_IMG_HANDLE: errorMsg = "Image handle error"; break;
                case CErrorCode.MV_FG_ERR_IMG_SUPPORT: errorMsg = "Image not supported"; break;
                case CErrorCode.MV_FG_ERR_IMG_PARAMETER: errorMsg = "Image parameter error"; break;
                case CErrorCode.MV_FG_ERR_IMG_OVERFLOW: errorMsg = "Image overflow error"; break;
                case CErrorCode.MV_FG_ERR_IMG_INITIALIZED: errorMsg = "Image processing not initialized"; break;
                case CErrorCode.MV_FG_ERR_IMG_RESOURCE: errorMsg = "Image resource error"; break;
                case CErrorCode.MV_FG_ERR_IMG_ENCRYPT: errorMsg = "Image encryption error"; break;
                case CErrorCode.MV_FG_ERR_IMG_FORMAT: errorMsg = "Invalid or unsupported image format"; break;
                case CErrorCode.MV_FG_ERR_IMG_SIZE: errorMsg = "Invalid or out of range image size"; break;
                case CErrorCode.MV_FG_ERR_IMG_STEP: errorMsg = "Image step parameter mismatch"; break;
                case CErrorCode.MV_FG_ERR_IMG_DATA_NULL: errorMsg = "Image data null"; break;
                case CErrorCode.MV_FG_ERR_IMG_ABILITY_ARG: errorMsg = "Invalid image algorithm parameter"; break;
                case CErrorCode.MV_FG_ERR_IMG_UNKNOW: errorMsg = "Unknown image processing error"; break;
                default: errorMsg = "Unknown error"; break;
            }

            Common.DebugWriteLine("Camera", 로그구분.오류, $"[{errorNum}] {message} {errorMsg}");
            Global.오류로그("Camera", "Error", $"[{errorNum}] {message} {errorMsg}", show);
            return false;
        }
        #endregion
    }
}