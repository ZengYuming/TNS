using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNS.Db
{
    /// <summary>
    /// 该类的结构并非存在于数据库，而是存在于json
    /// </summary>
    public class RealtimeReview
    {
        public string itineraryId { get; set; }//bookingId
        public string tuId { get; set; }
        public string siteId { get; set; }
        public string startDate { get; set; }// "2015-07-01T00:00:00Z",
        public string endDate { get; set; }// "2085-11-15T00:00:00Z",
        public string entityId { get; set; }// "tuid11564393412-11564393412-6606-2015-07-01-2085-11-15",
        public string questionGroupId { get; set; } // "0",
        public string comment { get; set; }// "Tony001,  itineraryID:11564393412,  checkin:2015-07-01,  checkout:2085-11-15,  timeofCommentCreation:7/3/2015 1:16:24 AM,  langugeId:1033,  siteId:1,  tagsOfFirstAnswer:1,2,3,  tagsOfSecondAnswer:3,4,  tagsOfThirdAnswer:5,8,13",
        public string userAgent { get; set; }
        public string createDate { get; set; }//"2015-07-03T07:30:52Z",
        public string updateDate { get; set; }//"2015-07-03T08:16:27Z",
        public string trackingId { get; set; }
        public string campaignId { get; set; } //"RTRH",
        public string legalCopySeen { get; set; }// false,
        public string id { get; set; } //"55963a2cc6232708fc9c1a9e",
        public string hotelId { get; set; }// "6606",
        public string locale { get; set; }// "en_US",
        public HotelManagementResponse[] hotelManagementResponses { get; set; }// [],
        public string[] answers { get; set; }// ["0", "0", "0"],
        public StructuredAnswer[] structuredAnswers { get; set; }
    }

    public class StructuredAnswer
    {
        public bool isHappy { get; set; }
        public string[] tags { get; set; }
        public string[] customTags { get; set; }
    }
    public class RealtimeReviewList
    {
        public RealtimeReview[] ArrayList { get; set; }
    }
    public class HotelManagementResponse
    {
        public string responseType { get; set; }//:"RESPOND",
        public string message { get; set; }//":"Hotel",
        public string created { get; set; }//":"2015-07-08T11:05:39Z"
    }
}
