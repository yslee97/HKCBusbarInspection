﻿namespace HKCBusbarInspection.UI.Control
{
    partial class ImageSave
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSave));
            this.g사진관리 = new DevExpress.XtraEditors.GroupControl();
            this.GridControl1 = new MvUtils.CustomGrid();
            this.BindSaveImage = new System.Windows.Forms.BindingSource(this.components);
            this.GridView1 = new MvUtils.CustomView();
            this.col카메라 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col원본저장 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col사본저장 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col사본유형 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col사진비율 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col사진품질 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.e비율 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.b정보저장 = new DevExpress.XtraEditors.SimpleButton();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.repositoryItemToggleSwitch2 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.g사진관리)).BeginInit();
            this.g사진관리.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindSaveImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e비율)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // g사진관리
            // 
            this.g사진관리.Controls.Add(this.GridControl1);
            this.g사진관리.Controls.Add(this.panelControl1);
            this.g사진관리.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g사진관리.Location = new System.Drawing.Point(0, 0);
            this.g사진관리.Name = "g사진관리";
            this.g사진관리.Size = new System.Drawing.Size(682, 478);
            this.g사진관리.TabIndex = 12;
            this.g사진관리.Text = "Save Image";
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.BindSaveImage;
            this.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl1.Location = new System.Drawing.Point(2, 27);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.e비율,
            this.repositoryItemToggleSwitch1,
            this.repositoryItemToggleSwitch2});
            this.GridControl1.Size = new System.Drawing.Size(678, 415);
            this.GridControl1.TabIndex = 0;
            this.GridControl1.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.True;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // BindSaveImage
            // 
            this.BindSaveImage.DataSource = typeof(HKCBusbarInspection.Schemas.사진저장);
            // 
            // GridView1
            // 
            this.GridView1.AllowColumnMenu = true;
            this.GridView1.AllowCustomMenu = true;
            this.GridView1.AllowExport = true;
            this.GridView1.AllowPrint = true;
            this.GridView1.AllowSettingsMenu = false;
            this.GridView1.AllowSummaryMenu = true;
            this.GridView1.ApplyFocusedRow = true;
            this.GridView1.Caption = "";
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col카메라,
            this.col원본저장,
            this.col사본저장,
            this.col사본유형,
            this.col사진비율,
            this.col사진품질});
            this.GridView1.FooterPanelHeight = 21;
            this.GridView1.GridControl = this.GridControl1;
            this.GridView1.GroupRowHeight = 21;
            this.GridView1.IndicatorWidth = 44;
            this.GridView1.MinColumnRowHeight = 24;
            this.GridView1.MinRowHeight = 16;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.GridView1.OptionsCustomization.AllowColumnMoving = false;
            this.GridView1.OptionsCustomization.AllowFilter = false;
            this.GridView1.OptionsCustomization.AllowGroup = false;
            this.GridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.GridView1.OptionsCustomization.AllowSort = false;
            this.GridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.GridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.GridView1.OptionsPrint.AutoWidth = false;
            this.GridView1.OptionsPrint.UsePrintStyles = false;
            this.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
            this.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.GridView1.OptionsView.ShowGroupPanel = false;
            this.GridView1.RowHeight = 20;
            // 
            // col카메라
            // 
            this.col카메라.AppearanceHeader.Options.UseTextOptions = true;
            this.col카메라.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col카메라.FieldName = "카메라";
            this.col카메라.Name = "col카메라";
            this.col카메라.Visible = true;
            this.col카메라.VisibleIndex = 0;
            // 
            // col원본저장
            // 
            this.col원본저장.AppearanceHeader.Options.UseTextOptions = true;
            this.col원본저장.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col원본저장.ColumnEdit = this.repositoryItemToggleSwitch1;
            this.col원본저장.FieldName = "원본저장";
            this.col원본저장.Name = "col원본저장";
            this.col원본저장.Visible = true;
            this.col원본저장.VisibleIndex = 1;
            // 
            // col사본저장
            // 
            this.col사본저장.AppearanceHeader.Options.UseTextOptions = true;
            this.col사본저장.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col사본저장.ColumnEdit = this.repositoryItemToggleSwitch2;
            this.col사본저장.FieldName = "사본저장";
            this.col사본저장.Name = "col사본저장";
            this.col사본저장.Visible = true;
            this.col사본저장.VisibleIndex = 2;
            // 
            // col사본유형
            // 
            this.col사본유형.AppearanceHeader.Options.UseTextOptions = true;
            this.col사본유형.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col사본유형.FieldName = "사본유형";
            this.col사본유형.Name = "col사본유형";
            this.col사본유형.Visible = true;
            this.col사본유형.VisibleIndex = 3;
            // 
            // col사진비율
            // 
            this.col사진비율.AppearanceHeader.Options.UseTextOptions = true;
            this.col사진비율.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col사진비율.FieldName = "사진비율";
            this.col사진비율.Name = "col사진비율";
            this.col사진비율.Visible = true;
            this.col사진비율.VisibleIndex = 4;
            // 
            // col사진품질
            // 
            this.col사진품질.AppearanceHeader.Options.UseTextOptions = true;
            this.col사진품질.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col사진품질.FieldName = "사진품질";
            this.col사진품질.Name = "col사진품질";
            this.col사진품질.Visible = true;
            this.col사진품질.VisibleIndex = 5;
            // 
            // e비율
            // 
            this.e비율.AutoHeight = false;
            this.e비율.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e비율.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.e비율.IsFloatValue = false;
            this.e비율.MaskSettings.Set("mask", "N00");
            this.e비율.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.e비율.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.e비율.Name = "e비율";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.b정보저장);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 442);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(3);
            this.panelControl1.Size = new System.Drawing.Size(678, 34);
            this.panelControl1.TabIndex = 5;
            // 
            // b정보저장
            // 
            this.b정보저장.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.b정보저장.Appearance.Options.UseFont = true;
            this.b정보저장.Dock = System.Windows.Forms.DockStyle.Right;
            this.b정보저장.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b정보저장.ImageOptions.SvgImage")));
            this.b정보저장.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.b정보저장.Location = new System.Drawing.Point(495, 3);
            this.b정보저장.Name = "b정보저장";
            this.b정보저장.Size = new System.Drawing.Size(180, 28);
            this.b정보저장.TabIndex = 1;
            this.b정보저장.Text = "Save";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(682, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 478);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(682, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 478);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(682, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 478);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // repositoryItemToggleSwitch1
            // 
            this.repositoryItemToggleSwitch1.AutoHeight = false;
            this.repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
            this.repositoryItemToggleSwitch1.OffText = "Off";
            this.repositoryItemToggleSwitch1.OnText = "On";
            // 
            // repositoryItemToggleSwitch2
            // 
            this.repositoryItemToggleSwitch2.AutoHeight = false;
            this.repositoryItemToggleSwitch2.Name = "repositoryItemToggleSwitch2";
            this.repositoryItemToggleSwitch2.OffText = "Off";
            this.repositoryItemToggleSwitch2.OnText = "On";
            // 
            // ImageSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.g사진관리);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ImageSave";
            this.Size = new System.Drawing.Size(682, 478);
            ((System.ComponentModel.ISupportInitialize)(this.g사진관리)).EndInit();
            this.g사진관리.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindSaveImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e비율)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl g사진관리;
        private MvUtils.CustomGrid GridControl1;
        private MvUtils.CustomView GridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit e비율;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton b정보저장;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource BindSaveImage;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Columns.GridColumn col카메라;
        private DevExpress.XtraGrid.Columns.GridColumn col원본저장;
        private DevExpress.XtraGrid.Columns.GridColumn col사본저장;
        private DevExpress.XtraGrid.Columns.GridColumn col사본유형;
        private DevExpress.XtraGrid.Columns.GridColumn col사진비율;
        private DevExpress.XtraGrid.Columns.GridColumn col사진품질;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch1;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}
