using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TNS.DataService.Interface;
using Framework.Core.Extensions;

namespace TNS.Db.JsonOnlineService
{
    public class RealtimeReviewService : BaseService, IRealtimeReviewService
    {
        private const string URLOFGETREVIEW = "http://privileged.test.reviewsvc.expedia.com/api/realtime/hotel/{0}?type=json&method=GET&start=0&items={1}";
        public List<TNS.Db.RealtimeReview> GetList(TNS.Metadata.Query.QRealtimeReview condition)
        {
            try
            {
                string urlOfGetReview = string.Format(URLOFGETREVIEW, condition.hotelId, int.MaxValue);
                string json = Framework.Core.Http.HttpHandler.GetResponseStringByGetMethod(urlOfGetReview);
                RealtimeReviewList realtimeReviewList = json.JsonDeserialize<RealtimeReviewList>();
                return filteRealtimeReview(condition, realtimeReviewList.ArrayList);
            }
            catch (Exception ex)
            {
                TNF.Util.Log.Logger.WriteException(ex);
            }

            return new List<TNS.Db.RealtimeReview>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">json data path</param>
        /// <returns></returns>
        public List<RealtimeReview> GetList_Stubbing(TNS.Metadata.Query.QRealtimeReview condition, string jsonPath)
        {
            IEnumerable<RealtimeReview> result = new List<RealtimeReview>();
            try
            {
                using (var sr = new System.IO.StreamReader(jsonPath))
                {
                    string json = sr.ReadToEnd();
                    RealtimeReviewList realtimeReviewList = json.JsonDeserialize<RealtimeReviewList>();
                    return filteRealtimeReview(condition, realtimeReviewList.ArrayList);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result.ToList();
        }

        public List<RealtimeReview> filteRealtimeReview(TNS.Metadata.Query.QRealtimeReview condition, IEnumerable<RealtimeReview> result)
        {
            try
            {
                result = result.Where(x => x.hotelId == condition.hotelId.ToString()).Select(x => x);
                if (!string.IsNullOrEmpty(condition.checkin))
                {
                    if (condition.isDateRange)
                    {
                        result = result.Where(i => i.startDate.ConvertToDateTime().CompareTo(condition.checkin.ConvertToDateTime()) >= 0).Select(i => i);
                    }
                    else
                    {
                        result = result.Where(i => i.startDate.ConvertToDateTime().CompareTo(condition.checkin.ConvertToDateTime()) == 0).Select(i => i);
                    }
                }
                if (!string.IsNullOrEmpty(condition.checkout))
                {
                    if (condition.isDateRange)
                    {
                        result = result.Where(x => x.endDate.ConvertToDateTime().CompareTo(condition.checkout.ConvertToDateTime()) <= 0).Select(x => x);
                    }
                    else {
                        result = result.Where(x => x.endDate.ConvertToDateTime().CompareTo(condition.checkout.ConvertToDateTime()) == 0).Select(x => x);                    
                    }
                }

                result = result.Take(condition.itemsCount);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return result.ToList();
        }
    }
}
