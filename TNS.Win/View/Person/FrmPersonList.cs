using System.ComponentModel;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using TNS.DataService.Interface;
using TNS.Db.Mysql;
using Framework.Core.Model;
using System.Collections.Generic;
using TNS.Db;
using TNS.Win.View.Person;
using System.Windows.Forms;
using TNS.Win.Util;
using TNS.Win.View.Backup;
using DevExpress.XtraSplashScreen;
using System.Data;

namespace TNS.Win
{
    public partial class FrmPersonList: RibbonForm
    {
        public FrmPersonList()
        {

            SplashScreenManager.ShowForm(this, typeof(FrmSplashScreen), true, true);
           
            InitializeComponent();
            InitSkinGallery();
            InitGrid();
             
            SplashScreenManager.CloseForm();
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        BindingList<Person> gridDataList = new BindingList<Person>();
        void InitGrid()
        {
            PageInfo pageInfo = new PageInfo();
            pageInfo.PageSize = 20;
            pageInfo.PageIndex = 0;
            IEnumerable<Person> personList = TNS.Db.TestDataService.PersonService.GetList();
            if (personList != null)
            {
                foreach (Person person in personList)
                {
                    gridDataList.Add(person);
                }
            }           
        
            gcPerson.DataSource = gridDataList;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvPerson.GetFocusedRow() != null)
            {
                Person person = (Person)gvPerson.GetFocusedRow();
                using (FrmPersonEdit frmEdit = new FrmPersonEdit(person))
                {                   
                    if (frmEdit.ShowDialog() ==  DialogResult.OK)
                    {
                        gcPerson.RefreshDataSource();
                    }
                }
            }
        }

        private void btnBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmBackupMysql frmBackupMysql = new FrmBackupMysql();
            frmBackupMysql.Show();
        }
    }
}