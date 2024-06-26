﻿namespace HKCBusbarInspection.UI.Control
{
    partial class LogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewer));
            this.GridControl1 = new MvUtils.CustomGrid();
            this.로그자료Bind = new System.Windows.Forms.BindingSource(this.components);
            this.GridView1 = new MvUtils.CustomView();
            this.col시간 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col구분 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col영역 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col제목 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col내용 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col작업자 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.b검색 = new DevExpress.XtraEditors.SimpleButton();
            this.e종료 = new DevExpress.XtraEditors.DateEdit();
            this.e시작 = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layout시작 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layout종료 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.BindLocalization = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.로그자료Bind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e종료.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e종료.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layout시작)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layout종료)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindLocalization)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.로그자료Bind;
            this.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl1.Location = new System.Drawing.Point(0, 40);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.Size = new System.Drawing.Size(836, 677);
            this.GridControl1.TabIndex = 3;
            this.GridControl1.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.True;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // 로그자료Bind
            // 
            this.로그자료Bind.DataSource = typeof(HKCBusbarInspection.Schemas.로그자료);
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
            this.col시간,
            this.col구분,
            this.col영역,
            this.col제목,
            this.col내용,
            this.col작업자});
            this.GridView1.FooterPanelHeight = 21;
            this.GridView1.GridControl = this.GridControl1;
            this.GridView1.GroupRowHeight = 21;
            this.GridView1.IndicatorWidth = 44;
            this.GridView1.MinColumnRowHeight = 24;
            this.GridView1.MinRowHeight = 16;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.Editable = false;
            this.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.GridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.GridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.GridView1.OptionsPrint.AutoWidth = false;
            this.GridView1.OptionsPrint.UsePrintStyles = false;
            this.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
            this.GridView1.OptionsView.ShowAutoFilterRow = true;
            this.GridView1.RowHeight = 20;
            // 
            // col시간
            // 
            this.col시간.AppearanceHeader.Options.UseTextOptions = true;
            this.col시간.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col시간.DisplayFormat.FormatString = "{0:yy-MM-dd HH:mm:ss.fff}";
            this.col시간.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col시간.FieldName = "시간";
            this.col시간.Name = "col시간";
            this.col시간.Visible = true;
            this.col시간.VisibleIndex = 0;
            // 
            // col구분
            // 
            this.col구분.AppearanceHeader.Options.UseTextOptions = true;
            this.col구분.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col구분.FieldName = "구분";
            this.col구분.Name = "col구분";
            this.col구분.Visible = true;
            this.col구분.VisibleIndex = 1;
            // 
            // col영역
            // 
            this.col영역.AppearanceHeader.Options.UseTextOptions = true;
            this.col영역.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col영역.FieldName = "영역";
            this.col영역.Name = "col영역";
            this.col영역.Visible = true;
            this.col영역.VisibleIndex = 2;
            // 
            // col제목
            // 
            this.col제목.AppearanceHeader.Options.UseTextOptions = true;
            this.col제목.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col제목.FieldName = "제목";
            this.col제목.Name = "col제목";
            this.col제목.Visible = true;
            this.col제목.VisibleIndex = 3;
            // 
            // col내용
            // 
            this.col내용.AppearanceHeader.Options.UseTextOptions = true;
            this.col내용.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col내용.FieldName = "내용";
            this.col내용.Name = "col내용";
            this.col내용.Visible = true;
            this.col내용.VisibleIndex = 4;
            // 
            // col작업자
            // 
            this.col작업자.AppearanceHeader.Options.UseTextOptions = true;
            this.col작업자.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col작업자.FieldName = "작업자";
            this.col작업자.Name = "col작업자";
            this.col작업자.Visible = true;
            this.col작업자.VisibleIndex = 5;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AutoScroll = false;
            this.layoutControl1.Controls.Add(this.b검색);
            this.layoutControl1.Controls.Add(this.e종료);
            this.layoutControl1.Controls.Add(this.e시작);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(836, 40);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // b검색
            // 
            this.b검색.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b검색.ImageOptions.SvgImage")));
            this.b검색.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.b검색.Location = new System.Drawing.Point(337, 9);
            this.b검색.Name = "b검색";
            this.b검색.Size = new System.Drawing.Size(112, 22);
            this.b검색.StyleController = this.layoutControl1;
            this.b검색.TabIndex = 5;
            this.b검색.Text = "조  회";
            // 
            // e종료
            // 
            this.e종료.EditValue = null;
            this.e종료.Location = new System.Drawing.Point(233, 9);
            this.e종료.Name = "e종료";
            this.e종료.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e종료.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e종료.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.e종료.Size = new System.Drawing.Size(96, 22);
            this.e종료.StyleController = this.layoutControl1;
            this.e종료.TabIndex = 4;
            // 
            // e시작
            // 
            this.e시작.EditValue = null;
            this.e시작.Location = new System.Drawing.Point(69, 9);
            this.e시작.Name = "e시작";
            this.e시작.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e시작.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e시작.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.e시작.Size = new System.Drawing.Size(96, 22);
            this.e시작.StyleController = this.layoutControl1;
            this.e시작.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layout시작,
            this.layout종료,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.Root.Size = new System.Drawing.Size(836, 40);
            this.Root.TextVisible = false;
            // 
            // layout시작
            // 
            this.layout시작.Control = this.e시작;
            this.layout시작.Location = new System.Drawing.Point(0, 0);
            this.layout시작.MaxSize = new System.Drawing.Size(164, 26);
            this.layout시작.MinSize = new System.Drawing.Size(164, 26);
            this.layout시작.Name = "layout시작";
            this.layout시작.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layout시작.Size = new System.Drawing.Size(164, 30);
            this.layout시작.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layout시작.Text = "시작일자";
            this.layout시작.TextSize = new System.Drawing.Size(48, 15);
            // 
            // layout종료
            // 
            this.layout종료.Control = this.e종료;
            this.layout종료.Location = new System.Drawing.Point(164, 0);
            this.layout종료.MaxSize = new System.Drawing.Size(164, 26);
            this.layout종료.MinSize = new System.Drawing.Size(164, 26);
            this.layout종료.Name = "layout종료";
            this.layout종료.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layout종료.Size = new System.Drawing.Size(164, 30);
            this.layout종료.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layout종료.Text = "종료일자";
            this.layout종료.TextSize = new System.Drawing.Size(48, 15);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(448, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(378, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.b검색;
            this.layoutControlItem3.Location = new System.Drawing.Point(328, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(120, 30);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(120, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlItem3.Size = new System.Drawing.Size(120, 30);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridControl1);
            this.Controls.Add(this.layoutControl1);
            this.Name = "LogViewer";
            this.Size = new System.Drawing.Size(836, 717);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.로그자료Bind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.e종료.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e종료.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e시작.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layout시작)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layout종료)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindLocalization)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MvUtils.CustomGrid GridControl1;
        private MvUtils.CustomView GridView1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton b검색;
        private DevExpress.XtraEditors.DateEdit e종료;
        private DevExpress.XtraEditors.DateEdit e시작;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layout시작;
        private DevExpress.XtraLayout.LayoutControlItem layout종료;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource 로그자료Bind;
        private System.Windows.Forms.BindingSource BindLocalization;
        private DevExpress.XtraGrid.Columns.GridColumn col시간;
        private DevExpress.XtraGrid.Columns.GridColumn col구분;
        private DevExpress.XtraGrid.Columns.GridColumn col영역;
        private DevExpress.XtraGrid.Columns.GridColumn col제목;
        private DevExpress.XtraGrid.Columns.GridColumn col내용;
        private DevExpress.XtraGrid.Columns.GridColumn col작업자;
    }
}
