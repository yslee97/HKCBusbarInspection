﻿using DevExpress.XtraWaitForm;
using HKCBusbarInspection.UI.Form;
using System;
using MvUtils;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HKCBusbarInspection.Schemas.유저정보;
using HKCBusbarInspection.Schemas;
using HKCBusbarInspection.UI.Control;
using System.Diagnostics;
using VM.Core;
using System.Collections.Generic;
using VM.PlatformSDKCS;
using System.Web.UI.WebControls;
using DevExpress.Utils;


namespace HKCBusbarInspection
{
    public partial class MainForm : DevExpress.XtraBars.TabForm
    {
        private LocalizationMain 번역 = new LocalizationMain();
        private UI.Form.WaitForm WaitForm;

        public MainForm()
        {
            InitializeComponent();
            this.ShowWaitForm();
            this.e프로젝트.Caption = $"IVM: {환경설정.프로젝트번호}";
            this.TabFormControl.SelectedPage = this.p결과뷰어;
            this.p환경설정.Enabled = false;
            this.p검사내역.Enabled = false;
            //this.p환경설정.Enabled = false;
            this.Shown += MainFormShown;
            this.FormClosing += MainFormClosing;
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Test용
            if (e.KeyCode == Keys.T)
            {
                //Global.검사자료?.Close();
                //Debug.WriteLine("T 눌림");
                //Global.마킹기제어.자료송신("SETTEXT \"001\" \"SendText!!!!!\"\r\n");
            }
            if (e.KeyCode == Keys.Y)
            {
                
            }
        }

        public void ShowWaitForm()
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(ShowWaitForm)); return; }

            WaitForm = new UI.Form.WaitForm() { ShowOnTopMode = ShowFormOnTopMode.AboveAll };
            WaitForm.Show(this);
        }
        public void HideWaitForm()
        {
            if (this.InvokeRequired) { this.BeginInvoke(new Action(HideWaitForm)); return; }

            WaitForm.Close();
        }

        private void MainFormShown(object sender, EventArgs e)
        {
            Global.Initialized += GlobalInitialized;
            Task.Run(() => { Global.Init(); });
        }

        private void GlobalInitialized(object sender, Boolean e) =>
            this.BeginInvoke(new Action(() => GlobalInitialized(e)));
        private void GlobalInitialized(Boolean e)
        {
            Global.Initialized -= GlobalInitialized;
            if (!e) { this.Close(); return; }
            this.HideWaitForm();
            Common.SetForegroundWindow(this.Handle.ToInt32());

            // 로그인
            //Login login = new Login();
            //if (Utils.ShowDialog(login, this) == DialogResult.OK)
            //{
            //    Global.DxLocalization();
            //    this.Init();
            //    Global.Start();
            //}
            //else this.Close();

            ////자동로그인
            Global.환경설정.시스템관리자로그인();
            Localization.SetCulture();
            Global.DxLocalization();
            this.Init();
            Global.Start();
            //}
        }

        private void Init()
        {
            this.SetLocalization();
            this.e결과뷰어.Init(ResultInspection.ViewTypes.Auto);
            this.e카메라뷰어.Init(ResultInspection.ViewTypes.Auto);
            this.e검사설정.Init();
            this.e장치설정.Init();
            this.e상태뷰어.Init();
            this.e로그내역.Init();
            this.e검사내역.Init();
            this.e변수설정.Init();
            this.p환경설정.Enabled = Global.환경설정.권한여부(유저권한구분.시스템);
            this.p검사내역.Enabled = Global.환경설정.권한여부(유저권한구분.관리자);
            this.TabFormControl.AllowMoveTabs = false;
            this.TabFormControl.AllowMoveTabsToOuterForm = false;

            if (Global.환경설정.동작구분 == 동작구분.Live)
                this.WindowState = FormWindowState.Maximized;
        }

        private void CloseForm()
        {
            this.e장치설정.Close();
            this.e로그내역.Close();
            this.e상태뷰어.Close();
            Global.Close();
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.환경설정.사용권한 == 유저권한구분.없음) this.CloseForm();
            else
            {
                e.Cancel = !Utils.Confirm(this, 번역.종료확인, Localization.확인.GetString());
                if (!e.Cancel) this.CloseForm();
            }
        }

        private void SetLocalization()
        {
            this.Text = this.번역.타이틀;
            this.타이틀.Caption = this.번역.타이틀;
            this.p결과뷰어.Text = this.번역.검사하기;
            this.p검사도구.Text = this.번역.카메라;
            this.p검사내역.Text = this.번역.검사내역;
            this.p환경설정.Text = this.번역.환경설정;
            this.t검사설정.Text = this.번역.검사설정;
            this.t장치설정.Text = this.번역.장치설정;
            this.t변수설정.Text = this.번역.변수설정;
            this.p로그내역.Text = this.번역.로그내역;
        }

        private class LocalizationMain
        {
            private enum Items
            {
                [Translation("Inspection", "검사하기")]
                검사하기,
                [Translation("History", "검사내역")]
                검사내역,
                [Translation("Preferences", "환경설정")]
                환경설정,
                [Translation("Settings", "검사설정")]
                검사설정,
                [Translation("Devices", "장치설정")]
                장치설정,
                [Translation("Variable", "변수설정")]
                변수설정,
                [Translation("Cameras", "카메라")]
                카메라,
                [Translation("Logs", "로그내역")]
                로그내역,
                [Translation("Are you want to exit the program?", "프로그램을 종료하시겠습나까?")]
                종료확인,
            }
            private String GetString(Items item) { return Localization.GetString(item); }

            public String 타이틀 { get => Localization.제목.GetString(); }
            public String 검사하기 { get => GetString(Items.검사하기); }
            public String 검사내역 { get => GetString(Items.검사내역); }
            public String 환경설정 { get => GetString(Items.환경설정); }
            public String 검사설정 { get => GetString(Items.검사설정); }
            public String 장치설정 { get => GetString(Items.장치설정); }
            public String 변수설정 { get => GetString(Items.변수설정); }
            public String 카메라 { get => GetString(Items.카메라); }
            public String 로그내역 { get => GetString(Items.로그내역); }
            public String 종료확인 { get => GetString(Items.종료확인); }
        }

        public void 모델변경적용()
        {
            this.e검사설정.모델변경적용();
            this.e결과뷰어.모델변경적용();
            this.e카메라뷰어.모델변경적용();
        }
    }
}
