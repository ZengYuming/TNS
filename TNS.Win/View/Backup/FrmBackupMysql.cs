using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TNS.Win.Util;

namespace TNS.Win.View.Backup
{
    public partial class FrmBackupMysql : DevExpress.XtraEditors.XtraForm
    {
        public FrmBackupMysql()
        {
            InitializeComponent();
        }

        private void btnPickUpPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                btnPickUpPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string outputDirectory = btnPickUpPath.Text;
            if (string.IsNullOrEmpty(outputDirectory))
            {
                MessageDxUtil.ShowTips("请选择存放路径!");
            }
            else
            {
                DateTime dateTime = DateTime.Now;
                string fileName = dateTime.Year.ToString() + dateTime.Month + dateTime.Day + ".sql";
                TNS.Db.Util.BackupHelper.StartBackup(outputDirectory + @"\" + fileName);
                MessageDxUtil.ShowTips("备份成功!");
            }
        }
    }
}