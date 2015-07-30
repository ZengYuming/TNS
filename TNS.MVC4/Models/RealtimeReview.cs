using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNS.MVC4.Models
{
    public class RealtimeReview
    {
        public string id { get; set; } //"55963a2cc6232708fc9c1a9e",
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string TagsOfFirstAnswer { get; set; }
        public string TagsOfSecondAnswer { get; set; }
        public string TagsOfThirdAnswer { get; set; }
        public string CustomTagsOfFirstAnswer { get; set; }
        public string CustomTagsOfSecondAnswer { get; set; }
        public string CustomTagsOfThirdAnswer { get; set; }
        public string CheckInDate { get; set; }// "2015-07-01T00:00:00Z",
        public string CheckOutDate { get; set; }// "2085-11-15T00:00:00Z",
        public string HotelId { get; set; }// "6606",           
        public string BookingId { get; set; }//bookingId
        public string Language { get; set; }// "en_US",
        public string Comment { get; set; }// "Tony001,  itineraryID:11564393412,  checkin:2015-07-01,  checkout:2085-11-15,  timeofCommentCreation:7/3/2015 1:16:24 AM,  langugeId:1033,  siteId:1,  tagsOfFirstAnswer:1,2,3,  tagsOfSecondAnswer:3,4,  tagsOfThirdAnswer:5,8,13",

    }
}