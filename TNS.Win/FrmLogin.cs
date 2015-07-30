using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using TNS.Win.Util;

namespace TNS.Win
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            SplashScreenManager.ShowForm(this, typeof(FrmSplashScreen), true, true);
            InitializeComponent();
            SplashScreenManager.CloseForm();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}