using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;

namespace TNS.Win
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region private property

        private string nameSpace = "TNS.Win.View";
        private string fullName = string.Empty;
        private string tag = string.Empty;
        private string parameter = string.Empty;

        #endregion
        public FrmMain()
        {
            SplashScreenManager.ShowForm(this, typeof(FrmSplashScreen), true, true);
            InitializeComponent();
            SetClickEvent();
            SplashScreenManager.CloseForm();
        }

        private void SetClickEvent()
        {
            //注册Ribbon所有BarItem的点击事件
            foreach (BarItem item in ribbon.Items)
            {
                item.ItemClick += new ItemClickEventHandler(ItemClick);
            }
        }

        private void ItemClick(object sender, ItemClickEventArgs e)
        {
            tag = string.Empty;
            if (e.Item.Tag == null) return;
            if (e.Item.Tag != null)
            {
                if (e.Item.Tag.ToString().Split('|').Length == 2)
                {
                    fullName = nameSpace + "." + e.Item.Tag.ToString().Split('|')[0];
                    tag = e.Item.Tag.ToString().Split('|')[1];
                }
                else if (e.Item.Tag.ToString().Split('|').Length == 3)
                {
                    fullName = nameSpace + "." + e.Item.Tag.ToString().Split('|')[0];
                    tag = e.Item.Tag.ToString().Split('|')[1];
                    parameter = e.Item.Tag.ToString().Split('|')[2];
                }
                else
                {
                    fullName = nameSpace + "." + e.Item.Tag.ToString();
                }
            }
            //如果要弹出对话框，则需要将对应BarItem的Tag设置为Dialog
            if (!string.IsNullOrEmpty(tag))
            {
                if (tag == "Dialog")
                {
                    Type type = Type.GetType(fullName);
                    Form form = (Form)type.Assembly.CreateInstance(fullName);
                    if (form == null)
                    {
                        return;
                    }
                    form.ShowDialog();

                }
            }
            else
            {
                Form f = FindChildForm(fullName);
                if (f != null)
                {
                    f.Focus();
                }
                else
                {
                    OpenForm(fullName);
                }
            }
        }

        private Form FindChildForm(string name)
        {
            Form child = null;
            foreach (Form f in MdiChildren)
            {
                if (f.Tag != null && f.Tag.ToString() == name)
                {
                    child = f;
                }
            }
            return child;
        }

        private void OpenForm(string formName)
        {
            Type type = Type.GetType(formName);
            Form form = (Form)type.Assembly.CreateInstance(formName);
            if (form == null)
            {
                return;
            }
            form.Tag = formName;
            form.MdiParent = this;
            form.Show();
        }
    }
}