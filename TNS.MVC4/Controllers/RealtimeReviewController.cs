using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNS.DataService.Interface;
using TNS.Db.JsonOnlineService;
using TNS.MVC4.Common;
using TNS.Metadata.Query;
using Framework.Core.Extensions;
using Framework.Core.Model;
using TNS.Metadata;
using TNF.Util.Log;
using TNS.Util.Language;

namespace TNS.MVC4.Controllers
{
    public class RealtimeReviewController : PagingController
    {
        private IRealtimeReviewService realtimeReviewService = new RealtimeReviewService();
        private const string JSONFILENAME = "RealtimeReview_TestData.json";
        //
        // GET: /Mockata/

        public ActionResult Index()
        {
            ViewData["DefaultRealtimeReview"] = ConfigHelper.DefaultRealtimeReview;
            return View();
        }



        [HttpPost]
        public ActionResult GetRealtimeReviews()
        {
            Pager = BuildPageInfo();
            var query = new QRealtimeReview();
            RequestHelper<QRealtimeReview>.RequestPropertys(HttpContext.Request, ref query);
            query.isDateRange = true;
            List<TNS.Db.RealtimeReview> list = new List<Db.RealtimeReview>();
            if (ConfigHelper.Stubbing)
            {
                list = realtimeReviewService.GetList_Stubbing(query, Server.MapPath("~/Data/") + JSONFILENAME);
            }
            else
            {
                list = realtimeReviewService.GetList(query);

            }

            var json = PagingHelper.ConvertJson(ConvertToRealtimeReviewList(list), Pager.Total);
            return Content(json);
        }


        public List<TNS.MVC4.Models.RealtimeReview> ConvertToRealtimeReviewList(List<TNS.Db.RealtimeReview> jsonModelList)
        {
            List<TNS.MVC4.Models.RealtimeReview> result = new List<TNS.MVC4.Models.RealtimeReview>();

            foreach (var jsonModel in jsonModelList)
            {
                result.Add(ConvertToRealtimeReview(jsonModel));
            }

            return result;
        }
        public TNS.MVC4.Models.RealtimeReview ConvertToRealtimeReview(TNS.Db.RealtimeReview jsonModel)
        {
            TNS.MVC4.Models.RealtimeReview result = new TNS.MVC4.Models.RealtimeReview();

            try
            {
                result.id = jsonModel.id;
                result.CheckInDate = jsonModel.startDate;
                result.CheckOutDate = jsonModel.endDate;
                result.HotelId = jsonModel.hotelId;
                result.BookingId = jsonModel.itineraryId;
                result.Language = LanguageHelper.GetLanguageText(jsonModel.locale).ToString();
                result.Comment = jsonModel.comment;


                if (jsonModel.structuredAnswers != null)
                {

                    //First Answer
                    if (jsonModel.structuredAnswers.Length > 0)
                    {
                        TNS.Db.StructuredAnswer firstAnswer = jsonModel.structuredAnswers[0];
                        result.FirstAnswer = firstAnswer.isHappy ? AnswerType.Happy.ToString() : AnswerType.Sad.ToString();
                        //Tags of First Answer
                        if (firstAnswer.tags != null)
                        {
                            for (int i = 0; i < firstAnswer.tags.Length; i++)
                            {
                                if (i != 0) { result.TagsOfFirstAnswer += ","; }
                                result.TagsOfFirstAnswer += Mockata.common.RealtimeReviewTagsHelper.GetTagByKey(firstAnswer.tags[i].ConvertToInteger());
                            }
                        }
                        //Custom Tags of First Answer
                        if (firstAnswer.customTags != null)
                        {
                            for (int i = 0; i < firstAnswer.customTags.Length; i++)
                            {
                                if (i != 0) { result.CustomTagsOfFirstAnswer += ","; }
                                result.CustomTagsOfFirstAnswer += firstAnswer.customTags[i];
                            }
                        }

                        //Second Answer
                        if (jsonModel.structuredAnswers.Length > 1)
                        {
                            TNS.Db.StructuredAnswer secondAnswer = jsonModel.structuredAnswers[1];
                            result.SecondAnswer = secondAnswer.isHappy ? AnswerType.Happy.ToString() : AnswerType.Sad.ToString();
                            //Tags of Second Answer
                            if (secondAnswer.tags != null)
                            {
                                for (int i = 0; i < secondAnswer.tags.Length; i++)
                                {
                                    if (i != 0) { result.TagsOfSecondAnswer += ","; }
                                    result.TagsOfSecondAnswer += Mockata.common.RealtimeReviewTagsHelper.GetTagByKey(secondAnswer.tags[i].ConvertToInteger());
                                }
                            }
                            //Custom Tags of Second Answer
                            if (secondAnswer.customTags != null)
                            {
                                for (int i = 0; i < secondAnswer.customTags.Length; i++)
                                {
                                    if (i != 0) { result.CustomTagsOfSecondAnswer += ","; }
                                    result.CustomTagsOfSecondAnswer += secondAnswer.customTags[i];
                                }
                            }

                            //Third Answer
                            if (jsonModel.structuredAnswers.Length > 2)
                            {
                                TNS.Db.StructuredAnswer thirdAnswer = jsonModel.structuredAnswers[2];
                                result.ThirdAnswer = thirdAnswer.isHappy ? AnswerType.Happy.ToString() : AnswerType.Sad.ToString();
                                //Tags of Second Answer
                                if (thirdAnswer.tags != null)
                                {
                                    for (int i = 0; i < thirdAnswer.tags.Length; i++)
                                    {
                                        if (i != 0) { result.TagsOfThirdAnswer += ","; }
                                        result.TagsOfThirdAnswer += Mockata.common.RealtimeReviewTagsHelper.GetTagByKey(thirdAnswer.tags[i].ConvertToInteger());
                                    }
                                }
                                //Custom Tags of Third Answer
                                if (thirdAnswer.customTags != null)
                                {
                                    for (int i = 0; i < thirdAnswer.customTags.Length; i++)
                                    {
                                        if (i != 0) { result.CustomTagsOfThirdAnswer += ","; }
                                        result.CustomTagsOfThirdAnswer += thirdAnswer.customTags[i];
                                    }
                                }
                            }
                            else
                            {
                                result.ThirdAnswer = AnswerType.None.ToString();
                            }
                        }
                        else
                        {
                            result.SecondAnswer = AnswerType.None.ToString();
                        }
                    }
                    else
                    {
                        result.FirstAnswer = AnswerType.None.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex);
            }

            return result;
        }
        public Mockata.Models.RealtimeReview ConvertToMockataParameter(TNS.MVC4.Models.RealtimeReview data)
        {
            Mockata.Models.RealtimeReview result = new Mockata.Models.RealtimeReview();
            result.id = data.id;
            result.FirstAnswer = (AnswerType)Enum.Parse(typeof(AnswerType), data.FirstAnswer);
            result.SecondAnswer = (AnswerType)Enum.Parse(typeof(AnswerType), data.SecondAnswer);
            result.ThirdAnswer = (AnswerType)Enum.Parse(typeof(AnswerType), data.ThirdAnswer);
            result.TagsOfFirstAnswer = data.TagsOfFirstAnswer;
            result.TagsOfSecondAnswer = data.TagsOfSecondAnswer;
            result.TagsOfThirdAnswer = data.TagsOfThirdAnswer;
            result.CustomTagsOfFirstAnswer = data.CustomTagsOfFirstAnswer;
            result.CustomTagsOfSecondAnswer = data.CustomTagsOfSecondAnswer;
            result.CustomTagsOfThirdAnswer = data.CustomTagsOfThirdAnswer;
            result.CheckInDate = data.CheckInDate;
            result.CheckOutDate = data.CheckOutDate;
            result.HotelId = data.HotelId;
            result.BookingId = data.BookingId;
            result.Language = (LanguageType)Enum.Parse(typeof(LanguageType), data.Language);
            result.Comment = data.Comment;
            return result;
        }
        //
        // POST: /Mockata/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var parameter = new TNS.MVC4.Models.RealtimeReview();
            RequestHelper<TNS.MVC4.Models.RealtimeReview>.RequestPropertys(HttpContext.Request, ref parameter);
            string validateMessage = ValidateDuplicateReview(parameter);
            if (string.IsNullOrEmpty(validateMessage))
            {
                Mockata.mockers.RealtimeReviewMocker mocker = new Mockata.mockers.RealtimeReviewMocker(ConvertToMockataParameter(parameter));
                string message = mocker.Mockup();
                Msg = string.IsNullOrEmpty(message) ? new MessageInfo(true, "Success！") : new MessageInfo(false, "Failed！");
            }
            else
            {
                Msg = new MessageInfo(false, "Failed! " + validateMessage);
            }

            return Content(Msg.JsonSerialize(), "text/html;charset=UTF-8");
        }

        private string ValidateDuplicateReview(TNS.MVC4.Models.RealtimeReview parameter)
        {
            string result = "";
            var query = new QRealtimeReview();
            query.hotelId = int.Parse(parameter.HotelId);
            query.checkin = parameter.CheckInDate;
            query.checkout = parameter.CheckOutDate;
            query.itemsCount = int.MaxValue;
            query.isDateRange = false;
            if (ConfigHelper.Stubbing)
            {
                if (realtimeReviewService.GetList_Stubbing(query, Server.MapPath("~/Data/") + JSONFILENAME).Count > 0)
                {
                    return "The review already exist.Please change the check out(or check in)date!";
                }
            }
            else
            {
                if (realtimeReviewService.GetList(query).Count > 0)
                {
                    return "The review already exist.Please change the check out(or check in)date!";
                }

            }
            return result;
        }
    }
}
