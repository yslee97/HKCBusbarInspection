﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKCBusbarInspection.UI.Form
{
    public partial class CalibrationForm : XtraForm
    {
        public CalibrationForm()
        {
            InitializeComponent();
            this.Load += FormLoad;
            this.Shown += FormShown;
        }
        private void FormLoad(object sender, EventArgs e)
        {
            this.e캘리브레이션.Init();
        }

        private void FormShown(object sender, EventArgs e)
        {
            //this.calibration1.BestFit();
        }
    }
}