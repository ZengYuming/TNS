using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TNS.DataService.Interface;
using Framework.Core.Model;
using Framework.Core.Extensions;
using DevExpress.XtraSplashScreen;

namespace TNS.Win.View.RealtimeReview
{
    public partial class FrmRealtimeReviewList : DevExpress.XtraEditors.XtraForm
    {
        private IRealtimeReviewService realtimeReviewService = new TNS.Db.JsonOnlineService.RealtimeReviewService();
        public FrmRealtimeReviewList()
        {
            SplashScreenManager.ShowForm(this, typeof(FrmSplashScreen), true, true);

            InitializeComponent();
            InitDefaultValue();
            LoadRTR();

            SplashScreenManager.CloseForm();
        }

        private void InitDefaultValue()
        {
            txtHotelId.Text = "6606";
            txtItemsCount.Text = "100";
        }

        private void LoadRTR()
        {
            //BindingList<TNS.Db.RealtimeReview> gridDataList = new BindingList<TNS.Db.RealtimeReview>();
            //List<TNS.Db.RealtimeReview> personList = realtimeReviewService.GetList(txtHotelId.Text.ConvertToInteger(), txtItemsCount.Text.ConvertToInteger());
            //if (personList != null)
            //{
            //    foreach (var person in personList)
            //    {
            //        gridDataList.Add(person);
            //    }
            //}
            //gcRTRList.DataSource = gridDataList;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadRTR();
        }
    }
}