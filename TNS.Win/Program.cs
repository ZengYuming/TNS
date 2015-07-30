using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using TNS.Win.View.Backup;

namespace TNS.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");



            //using (FrmLogin loginForm = new FrmLogin())
            //{
            //    if (loginForm.ShowDialog() == DialogResult.OK)
            //    {
                    FrmMain mainForm = new FrmMain();
                    //mainForm.Icon = loginForm.Icon;
                    Application.Run(mainForm);
            //    }
            //}
        }
    }
}