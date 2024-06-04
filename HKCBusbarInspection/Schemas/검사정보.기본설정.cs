﻿using MvUtils;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace HKCBusbarInspection.Schemas
{
    public enum 카메라구분
    {
        [ListBindable(false)]
        None = 0,
        [Description("Cam1(Top Camera)")]
        Cam01 = 1,
        [Description("Cam2(Side Camera)")]
        Cam02 = 2,
        [Description("Cam3(LPoint Camera)")]
        Cam03 = 3,
        [Description("Cam4(Bottom Camera)")]
        Cam04 = 4,
        [Description("Cam5(Tray Check)")]
        Cam05 = 5,
    }

    public enum 장치구분
    {
        [Description("None"), Camera(false)]
        None = 0,
        [Description("Cam01"), Camera(true)]
        Cam01 = 카메라구분.Cam01,
        [Description("Cam02"), Camera(true)]
        Cam02 = 카메라구분.Cam02,
        [Description("Cam03"), Camera(true)]
        Cam03 = 카메라구분.Cam03,
        [Description("Cam04"), Camera(true)]
        Cam04 = 카메라구분.Cam04,
        [Description("Cam05"), Camera(true)]
        Cam05 = 카메라구분.Cam05,
    }

    public enum 결과분류
    {
        None,
        Summary,
        Detail,
    }

    public enum 검사그룹
    {
        [Description("None"), Translation("None", "없음")]
        None,
        [Description("CTQ"), Translation("CTQ")]
        CTQ,
        [Description("Surface"), Translation("Surface", "외관검사")]
        Surface,
        [Description("Etc"), Translation("Etc", "기타")]
        Etc,
    }


    public enum 검사항목 : Int32
    {
        [Result(), ListBindable(false)]
        None,
        //작은홀
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌상홀경")]
        좌상홀경 = 101,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우상홀경")]
        우상홀경 = 102,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌하홀경")]
        좌하홀경 = 103,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우하홀경")]
        우하홀경 = 104,

        //사각홀 가로세로
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌상홀가로")]
        좌상홀가로 = 201,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌상홀세로")]
        좌상홀세로 = 202,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌상홀위치도")]
        좌상홀위치도 = 203,

        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우상홀가로")]
        우상홀가로 = 204,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우상홀세로")]
        우상홀세로 = 205,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우상홀위치도")]
        우상홀위치도 = 206,

        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌중홀가로")]
        좌중홀가로 = 207,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌중홀세로")]
        좌중홀세로 = 208,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌중홀위치도")]
        좌중홀위치도 = 209,

        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우중홀가로")]
        우중홀가로 = 210,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우중홀세로")]
        우중홀세로 = 211,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우중홀위치도")]
        우중홀위치도 = 212,

        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌하홀가로")]
        좌하홀가로 = 213,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌하홀세로")]
        좌하홀세로 = 214,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌하홀위치도")]
        좌하홀위치도 = 215,

        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우하홀가로")]
        우하홀가로 = 216,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우하홀세로")]
        우하홀세로 = 217,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우하홀위치도")]
        우하홀위치도 = 218,

        //좌측슬롯[ -2.5 / 8.375 / 19.25 / 30.125 / 41 ]
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯1거리")]
        좌슬롯1거리 = 301,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯2거리")]
        좌슬롯2거리 = 302,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯3거리")]
        좌슬롯3거리 = 303,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯4거리")]
        좌슬롯4거리 = 304,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯5거리")]
        좌슬롯5거리 = 305,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯1위치도")]
        좌슬롯1위치도 = 306,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯2위치도")]
        좌슬롯2위치도 = 307,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯3위치도")]
        좌슬롯3위치도 = 308,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯4위치도")]
        좌슬롯4위치도 = 309,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯5위치도")]
        좌슬롯5위치도 = 310,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "좌슬롯Burr")]
        좌슬롯Burr = 311,

        //중앙슬롯[ -2.5 / 8.375 / 19.25 / 30.125 / 41 ]
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯1거리")]
        중슬롯1거리 = 401,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯2거리")]
        중슬롯2거리 = 402,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯3거리")]
        중슬롯3거리 = 403,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯4거리")]
        중슬롯4거리 = 404,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯5거리")]
        중슬롯5거리 = 405,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯1위치도")]
        중슬롯1위치도 = 406,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯2위치도")]
        중슬롯2위치도 = 407,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯3위치도")]
        중슬롯3위치도 = 408,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯4위치도")]
        중슬롯4위치도 = 409,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯5위치도")]
        중슬롯5위치도 = 410,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "중슬롯Burr")]
        중슬롯Burr = 411,

        //우측슬롯[ -2.5 / 8.375 / 19.25 / 30.125 / 41 ]
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯1거리")]
        우슬롯1거리 = 501,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯2거리")]
        우슬롯2거리 = 502,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯3거리")]
        우슬롯3거리 = 503,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯4거리")]
        우슬롯4거리 = 504,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯5거리")]
        우슬롯5거리 = 505,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯1위치도")]
        우슬롯1위치도 = 506,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯2위치도")]
        우슬롯2위치도 = 507,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯3위치도")]
        우슬롯3위치도 = 508,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯4위치도")]
        우슬롯4위치도 = 509,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯5위치도")]
        우슬롯5위치도 = 510,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam01, None, "우슬롯Burr")]
        우슬롯Burr = 511,

        //측면카메라
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam02, None, "측면가로")]
        측면가로 = 601,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam02, None, "측면세로")]
        측면세로 = 602,
        [Result(검사그룹.CTQ, 결과분류.Summary, 장치구분.Cam02, None, "측면홀경")]
        측면홀경 = 603,

        //버검사
        [Result(검사그룹.Surface, 결과분류.Summary, 장치구분.Cam03, None, "L자부버")]
        L자부버 = 701,

        //표면검사
        [Result(검사그룹.Surface, 결과분류.Summary, 장치구분.Cam01, None, "상부표면")]
        상부표면 = 801,
        [Result(검사그룹.Surface, 결과분류.Summary, 장치구분.Cam04, None, "하부표면")]
        하부표면 = 802,
        [Result(검사그룹.Surface, 결과분류.Summary, 장치구분.Cam02, None, "측면표면")]
        측면표면 = 803,
    }

    public enum 단위구분
    {
        [Description("mm")]
        mm = 0,
        [Description("OK/NG")]
        ON = 1,
        [Description("EA")]
        EA = 2,
        [Description("Grade")]
        GA = 3,
    }

    public enum 결과구분
    {
        [Description("Waiting"), Translation("Waiting", "대기중")]
        WA = 0,
        [Description("Measuring"), Translation("Measuring", "검사중")]
        ME = 1,
        [Description("PS"), Translation("Pass", "통과")]
        PS = 2,
        [Description("ER"), Translation("Error", "오류")]
        ER = 3,
        [Description("NG"), Translation("NG", "불량")]
        NG = 5,
        [Description("OK"), Translation("OK", "양품")]
        OK = 7,
    }

    [Table("inspd")]
    public class 검사정보
    {
        [Column("idwdt", Order = 0), Required, Key, JsonProperty("idwdt"), Translation("Time", "검사일시")]
        public DateTime 검사일시 { get; set; } = DateTime.Now;
        [NotMapped, JsonProperty("idnam"), Translation("Name", "명칭")]
        public String 검사명칭 { get; set; } = String.Empty;
        [Column("iditm", Order = 1), Required, Key, JsonProperty("iditm"), Translation("Item", "검사항목")]
        public 검사항목 검사항목 { get; set; } = 검사항목.None;
        [Column("idgrp"), JsonProperty("idgrp"), Translation("Group", "검사그룹")]
        public 검사그룹 검사그룹 { get; set; } = 검사그룹.None;
        [Column("iddev"), JsonProperty("iddev"), Translation("Device", "검사장치")]
        public 장치구분 검사장치 { get; set; } = 장치구분.None;
        [Column("idcat"), JsonProperty("idcat"), Translation("Category", "결과유형")]
        public 결과분류 결과분류 { get; set; } = 결과분류.None;
        [Column("iduni"), JsonProperty("iduni"), Translation("Unit", "단위"), BatchEdit(true)]
        public 단위구분 측정단위 { get; set; } = 단위구분.mm;
        [Column("idstd"), JsonProperty("idstd"), Translation("Norminal", "기준값"), BatchEdit(true)]
        public Decimal 기준값 { get; set; } = 0m;
        [Column("idmin"), JsonProperty("idmin"), Translation("Min", "최소값"), BatchEdit(true)]
        public Decimal 최소값 { get; set; } = 0m;
        [Column("idmax"), JsonProperty("idmax"), Translation("Max", "최대값"), BatchEdit(true)]
        public Decimal 최대값 { get; set; } = 0m;
        [Column("idoff"), JsonProperty("idoff"), Translation("Offset", "보정값"), BatchEdit(true)]
        public Decimal 보정값 { get; set; } = 0m;
        [Column("idcal"), JsonProperty("idcal"), Translation("Calib(µm)", "교정(µm)"), BatchEdit(true)]
        public Decimal 교정값 { get; set; } = 0m;
        [Column("idmes"), JsonProperty("idmes"), Translation("Measure", "측정값")]
        public Decimal 측정값 { get; set; } = 0m;
        [Column("idval"), JsonProperty("idval"), Translation("Value", "결과값")]
        public Decimal 결과값 { get; set; } = 0m;
        [NotMapped, JsonProperty("idrel"), Translation("Real", "실측값")]
        public Decimal 실측값 { get; set; } = 0m;
        [Column("idres"), JsonProperty("idres"), Translation("Result", "판정")]
        public 결과구분 측정결과 { get; set; } = 결과구분.WA;
        [NotMapped, JsonProperty("idmag"), Translation("Margin"), BatchEdit(true)]
        public Decimal 마진값 { get; set; } = 0m;
        [NotMapped, JsonProperty("iduse"), Translation("Used", "검사"), BatchEdit(true)]
        public Boolean 검사여부 { get; set; } = true;

        [NotMapped, JsonIgnore]
        public Double 검사시간 = 0;
        [NotMapped, JsonIgnore]
        public String 변수명칭 = String.Empty;
        [NotMapped, JsonIgnore]
        public Boolean 카메라여부 = false;
        [NotMapped, JsonIgnore]
        public 검사항목 결과항목 = 검사항목.None;
        [NotMapped, JsonIgnore]
        public Int32 결과부호 = 1;

        public 검사정보() { }
        public 검사정보(검사정보 정보) { this.Set(정보); }

        public void Init()
        {
            this.카메라여부 = CameraAttribute.IsCamera(this.검사장치);
            ResultAttribute a = Utils.GetAttribute<ResultAttribute>(this.검사항목);
            this.변수명칭 = a.변수명칭;
            this.결과항목 = a.결과항목;
            this.결과부호 = a.결과부호;
        }

        public void Reset(DateTime? 일시 = null)
        {
            if (일시 != null) this.검사일시 = (DateTime)일시;
            this.측정값 = 0;
            this.결과값 = 0;
            this.측정결과 = 결과구분.WA;
        }
        public void Set(검사정보 정보)
        {
            if (정보 == null) return;
            foreach (PropertyInfo p in typeof(검사정보).GetProperties())
            {
                if (!p.CanWrite) continue;
                Object v = p.GetValue(정보);
                if (v == null) continue;
                p.SetValue(this, v);
            }
            this.Reset(null);
            this.Init();
        }

        public Boolean 교정계산()
        {
            if (this.측정값 <= 0) return false;
            this.교정값 = Convert.ToDecimal(Math.Round((this.실측값 - this.보정값) / this.측정값 * 1000, 9));
            return true;
        }

        public 결과구분 결과계산()
        {
            Boolean ok = this.결과값 >= this.최소값 && this.결과값 <= this.최대값;
            this.측정결과 = ok ? 결과구분.OK : 결과구분.NG;
            return this.측정결과;
        }

        public String DisplayText(Decimal value)
        {
            //if (this.검사항목 == 검사항목.QrLegibility) return Utils.GetDescription((큐알등급)Convert.ToInt32(value));
            if (this.측정단위 == 단위구분.EA) return Utils.FormatNumeric(value);
            if (this.측정단위 == 단위구분.ON) return value == 1 ? "OK" : "NG";
            return String.Empty;
        }

        private String[] AppearanceFields = new String[] { nameof(측정결과), nameof(최소값), nameof(최대값), nameof(기준값), nameof(결과값) };
        public void SetAppearance(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e == null || !AppearanceFields.Contains(e.Column.FieldName)) return;
            PropertyInfo p = typeof(검사정보).GetProperty(e.Column.FieldName);
            if (p.Name == nameof(결과값) || p.Name == nameof(측정결과))
                e.Appearance.ForeColor = 환경설정.결과표현색상(this.측정결과);
            if (p.PropertyType != typeof(Decimal)) return;
            Object v = p.GetValue(this);
            if (v == null) return;
            String display = DisplayText((Decimal)v);
            if (!String.IsNullOrEmpty(display)) e.DisplayText = display;
        }
    }

    #region Attributes
    public class CameraAttribute : Attribute
    {
        public Boolean Whether = true;
        public CameraAttribute(Boolean cam) { Whether = cam; }

        public static Boolean IsCamera(장치구분 구분)
        {
            CameraAttribute a = Utils.GetAttribute<CameraAttribute>(구분);
            if (a == null) return false;
            return a.Whether;
        }
    }

    public class ResultAttribute : Attribute
    {
        public 검사그룹 검사그룹 = 검사그룹.None;
        public 결과분류 결과분류 = 결과분류.None;
        public 장치구분 장치구분 = 장치구분.None;
        public 검사항목 결과항목 = 검사항목.None;
        public String 변수명칭 = String.Empty;
        public Int32 결과부호 = 1;
        public ResultAttribute() { }
        public ResultAttribute(검사그룹 그룹, 결과분류 결과) { 검사그룹 = 그룹; 결과분류 = 결과; }
        public ResultAttribute(검사그룹 그룹, 결과분류 결과, 장치구분 장치) { 검사그룹 = 그룹; 결과분류 = 결과; 장치구분 = 장치; }
        public ResultAttribute(검사그룹 그룹, 결과분류 결과, 장치구분 장치, 검사항목 항목) { 검사그룹 = 그룹; 결과분류 = 결과; 장치구분 = 장치; 결과항목 = 항목; }
        public ResultAttribute(검사그룹 그룹, 결과분류 결과, 장치구분 장치, 검사항목 항목, String 변수) { 검사그룹 = 그룹; 결과분류 = 결과; 장치구분 = 장치; 결과항목 = 항목; 변수명칭 = 변수; }
        public ResultAttribute(검사그룹 그룹, 결과분류 결과, 장치구분 장치, 검사항목 항목, String 변수, Int32 부호) { 검사그룹 = 그룹; 결과분류 = 결과; 장치구분 = 장치; 결과항목 = 항목; 변수명칭 = 변수; 결과부호 = 부호; }

        public static String VarName(검사항목 항목)
        {
            ResultAttribute a = Utils.GetAttribute<ResultAttribute>(항목);
            if (a == null) return String.Empty;
            return a.변수명칭;
        }
        public static Int32 ValueFactor(검사항목 항목)
        {
            ResultAttribute a = Utils.GetAttribute<ResultAttribute>(항목);
            if (a == null) return 1;
            return a.결과부호;
        }
    }
    #endregion
}