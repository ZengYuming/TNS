using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using TNS.DataService.Interface;
using Framework.Core.Extensions;

namespace TNS.Win.View.RealtimeReview
{
    public partial class FrmRealtimeReviewNew : DevExpress.XtraEditors.XtraForm
    {
        private IRealtimeReviewService realtimeReviewService = new TNS.Db.JsonOnlineService.RealtimeReviewService();
        public FrmRealtimeReviewNew()
        {
            SplashScreenManager.ShowForm(this, typeof(FrmSplashScreen), true, true);
            InitializeComponent();
            InitDefaultValue();
            SplashScreenManager.CloseForm();
        }

        private void InitDefaultValue()
        {
            //icbeFirstAnswer.SelectedIndex = 0;
            //icbeSecondAnswer.SelectedIndex = 0;
            //icbeThirdAnswer.SelectedIndex = 0;
            //txtTagsOfFirstAnswer.Text = "1,2,3";
            //txtTagsOfSecondAnswer.Text = "1,2,3";
            //txtTagsOfThirdAnswer.Text = "1,2,3";
            //deCheckIn.DateTime = DateTime.Now.AddDays(-1);
            //txtHotelId.Text = "6606";
            //List<TNS.Db.RealtimeReview> personList = realtimeReviewService.GetList(txtHotelId.Text.ConvertToInteger(), 1);
            //if (personList != null && personList.Count > 0)
            //{
            //    deCheckOut.DateTime = personList[0].endDate.ConvertToDateTime();
            //}
            //else
            //{
            //    deCheckOut.DateTime = DateTime.Now.AddDays(1);
            //}
            //txtBookingId.Text = "11564393412";
            //txtLangId.Text = "1033";
            //txtSiteId.Text = "1";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Mockata.Models.RealtimeReview parameter = new Mockata.Models.RealtimeReview();
            //parameter.FirstAnswer = icbeFirstAnswer.Value.ToString().ConvertToInteger();
            //parameter.SecondAnswer = icbeSecondAnswer.Value.ToString().ConvertToInteger();
            //parameter.thirdAnswer = icbeThirdAnswer.Value.ToString().ConvertToInteger();
            //parameter.tagsOfFirstAnswer = txtTagsOfFirstAnswer.Text;
            //parameter.tagsOfSecondAnswer = txtTagsOfSecondAnswer.Text;
            //parameter.tagsOfThirdAnswer = txtTagsOfThirdAnswer.Text;
            //parameter.checkInDate = string.Format("{0:yyyy-MM-dd}", deCheckIn.DateTime);
            //parameter.checkOutDate = string.Format("{0:yyyy-MM-dd}", deCheckOut.DateTime);
            //parameter.hotelId = txtHotelId.Text;
            //parameter.bookingId = txtBookingId.Text;
            //parameter.langId = txtLangId.Text;
            //parameter.siteId = txtSiteId.Text;
            Mockata.mockers.RealtimeReviewMocker mocker = new Mockata.mockers.RealtimeReviewMocker(parameter);
            string message = mocker.Mockup();
            if (!string.IsNullOrEmpty(message))
            {
                TNS.Win.Util.MessageDxUtil.ShowError(message);
            }
        }

    }
}