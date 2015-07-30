using Mockata.common;
using Mockata.Models;
using System;
using TNS.Metadata;
using TNS.Util.Language;

namespace Mockata.mockers
{

    public class RealtimeReviewMocker
    {
        //iId="$1"
        //checkin="$2"
        //checkout="$3"
        //hId="$4"
        //currentTime=$(date +%Y-%m-%d-%H-%M-%S)
        //langId="$5"
        //siteId="$6"
        //comment="Tony001,++itineraryID:$iId,++checkin:$checkin,++checkout:$checkout,++timeofCommentCreation:$currentTime,++langugeId:$langId,++siteId:$siteId"
        RealtimeReview model = new RealtimeReview();
        public RealtimeReviewMocker(RealtimeReview model)
        {
            this.model = model;
        }

        public string Mockup()
        {
            string result = "";
            try
            {
                //model.CurrentTime = DateTime.Now.ToString();           

                string urlRealtimeReview = getUrlOfCreateReviewRecord(model);

                //realtime review
                result = Framework.Core.Http.HttpHandler.SendGetHttpReques(urlRealtimeReview);

                //first answer
                result += mockFirstAnswer();

                //second smiley
                result += mockSecondAnswer();

                //third smiley
                result += mockThirdAnswer();

                //comment
                string urlComment = getUrlOfAddComment(model);
                result += Framework.Core.Http.HttpHandler.SendPostHttpRequest(urlComment);
            }
            catch (Exception ex)
            {
                TNF.Util.Log.Logger.WriteException(ex);
            }

            return result;
        }

        public string getJsonDataOfTags(AnswerType answer, string tags, string customTags)
        {
            string jsonData = "{\"isHappy\":" + (answer == AnswerType.Happy ? "true" : "false") + ",\"tags\":[" + tags + "],\"customTags\":[" + customTags + "]}";
            return jsonData;
        }

        #region private member
        private string mockFirstAnswer()
        {
            string result = "";
            AnswerType answer = model.FirstAnswer;
            if (answer != AnswerType.None)
            {
                //answer
                string urlFirstSmiley = getUrlOfFirstSmiley(model);
                result = Framework.Core.Http.HttpHandler.SendPostHttpRequest(urlFirstSmiley);
                //tags
                string urlTags = getUrlOfTagsOfFirstAnswer(model);
                string jsonData = getJsonDataOfTags(answer, model.TagsOfFirstAnswer, model.CustomTagsOfFirstAnswer);
                result = Framework.Core.Http.HttpHandler.SendPostHttpRequest(urlTags, jsonData);
            }
            return result;
        }

        private string mockSecondAnswer()
        {
            string result = "";
            AnswerType answer = model.SecondAnswer;
            if (answer != AnswerType.None)
            {
                //answer
                string urlSecondSmiley = getUrlOfSecondSmiley(model);
                result = Framework.Core.Http.HttpHandler.SendPostHttpRequest(urlSecondSmiley);

                //tags
                string urlTags = getUrlOfTagsOfSecondAnswer(model);
                string jsonData = getJsonDataOfTags(answer, model.TagsOfSecondAnswer, model.CustomTagsOfSecondAnswer);
                result = Framework.Core.Http.HttpHandler.SendPostHttpRequest(urlTags, jsonData);
            }
            return result;
        }

        private string mockThirdAnswer()
        {
            string result = "";
            AnswerType answer = model.ThirdAnswer;
            if (answer != AnswerType.None)
            {
                string urlThirdSmiley = getUrlOfThirdSmiley(model);
                result = Framework.Core.Http.HttpHandler.SendPostHttpRequest(urlThirdSmiley);
                //tags
                string urlTags = getUrlOfTagsOfThirdAnswer(model);
                string jsonData = getJsonDataOfTags(answer, model.TagsOfThirdAnswer, model.CustomTagsOfThirdAnswer);
                result = Framework.Core.Http.HttpHandler.SendPostHttpRequest(urlTags, jsonData);
            }
            return result;
        }

        private static string getUrlOfCreateReviewRecord(RealtimeReview parameter)
        {
            return string.Format("http://privileged.test.reviewsvc.expedia.com/api/test/realtime/hotel/create/review/{0}/tuid{0}/{1}/0/{2}/{3}/{4}/{5}",
                parameter.BookingId,
               LanguageHelper.GetSiteId(parameter.Language),
                parameter.HotelId,
                parameter.CheckInDate,
                parameter.CheckOutDate,
                (int)parameter.Language
                );
        }

        private static string getUrlOfFirstSmiley(RealtimeReview parameter)
        {
            return string.Format("http://test.reviewsvc.expedia.com/api/realtimereview/respondToQuestion/{0}/tuid{0}/{1}/tuid{0}-{0}-{2}-{3}-{4}/0/0/{5}?legalCopySeen=true",
                parameter.BookingId,//0
                            LanguageHelper.GetSiteId(parameter.Language),//1
                            parameter.HotelId,//2
                            parameter.CheckInDate,//3
                            parameter.CheckOutDate,//4
                            (int)parameter.FirstAnswer//5
                );
        }

        private static string getUrlOfSecondSmiley(RealtimeReview parameter)
        {
            return string.Format("http://test.reviewsvc.expedia.com/api/realtimereview/respondToQuestion/{0}/tuid{0}/{1}/tuid{0}-{0}-{2}-{3}-{4}/0/1/{5}?legalCopySeen=true",
                parameter.BookingId,//0
                            LanguageHelper.GetSiteId(parameter.Language),//1
                            parameter.HotelId,//2
                            parameter.CheckInDate,//3
                            parameter.CheckOutDate,//4
                            (int)parameter.SecondAnswer//5
                );
        }

        private static string getUrlOfThirdSmiley(RealtimeReview parameter)
        {
            return string.Format("http://test.reviewsvc.expedia.com/api/realtimereview/respondToQuestion/{0}/tuid{0}/{1}/tuid{0}-{0}-{2}-{3}-{4}/0/2/{5}?legalCopySeen=true",
                parameter.BookingId,//0
                             LanguageHelper.GetSiteId(parameter.Language),//1
                            parameter.HotelId,//2
                            parameter.CheckInDate,//3
                            parameter.CheckOutDate,//4
                            (int)parameter.ThirdAnswer//5
                );
        }

        private static string getUrlOfAddComment(RealtimeReview parameter)
        {
            return string.Format("http://test.reviewsvc.expedia.com/api/realtimereview/addComment/{0}/tuid{0}/{1}/tuid{0}-{0}-{2}-{3}-{4}/0?comment={5}",
             parameter.BookingId,//0
                           LanguageHelper.GetSiteId(parameter.Language),//1
                            parameter.HotelId,//2
                            parameter.CheckInDate,//3
                            parameter.CheckOutDate,//4
                            parameter.Comment//5
                );
        }

        private static string getUrlOfTagsOfFirstAnswer(RealtimeReview parameter)
        {
            return getUrlOfTags(parameter, 0);
        }

        private static string getUrlOfTagsOfSecondAnswer(RealtimeReview parameter)
        {
            return getUrlOfTags(parameter, 1);
        }

        private static string getUrlOfTagsOfThirdAnswer(RealtimeReview parameter)
        {
            return getUrlOfTags(parameter, 2);
        }

        private static string getUrlOfTags(RealtimeReview parameter, int questionIndex)
        {
            //   /api/realtimereview/answer/{itineraryId}/{tuId}/{siteId}/{entityId}/{questionGroupId}/{questionIndex}
            const string TUID = "tuid";
            string itineraryId = parameter.BookingId;
            string tuId = TUID + parameter.BookingId;
            int siteId = LanguageHelper.GetSiteId(parameter.Language);
            string entityId = tuId + "-" + itineraryId + "-" + parameter.HotelId + "-" + parameter.CheckInDate + "-" + parameter.CheckOutDate;
            string questionGroupId = "0";


            return string.Format("http://test.reviewsvc.expedia.com/api/realtimereview/answer/{0}/{1}/{2}/{3}/{4}/{5}?trackingId&campaignId=RTRH&legalCopySeen=true&className=HappySadTaggedAnswer&experimentId=7348&questionSet=7348-1",
            itineraryId,
            tuId,
            siteId,
            entityId,
            questionGroupId,
            questionIndex
                );
        }
        #endregion
    }

}
