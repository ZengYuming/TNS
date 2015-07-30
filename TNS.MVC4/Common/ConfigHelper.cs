using System.Configuration;
using Framework.Core.Extensions;
using System;
using System.Collections.Generic;
using TNS.Metadata;

namespace TNS.MVC4.Common
{
    public class ConfigHelper
    {
        public static int DefaultPageSize
        {
            get { return ConfigurationManager.AppSettings["DefaultPageSize"].ConvertToInteger(10); }
        }
        private static Mockata.Models.RealtimeReview _defaultRealtimeReview = null;
        public static Mockata.Models.RealtimeReview DefaultRealtimeReview
        {
            get
            {
                if (_defaultRealtimeReview == null)
                {
                    _defaultRealtimeReview = new Mockata.Models.RealtimeReview();
                    _defaultRealtimeReview.TagsOfFirstAnswer = ConfigurationManager.AppSettings["TagsOfFirstAnswer"];
                    _defaultRealtimeReview.TagsOfSecondAnswer = ConfigurationManager.AppSettings["TagsOfSecondAnswer"];
                    _defaultRealtimeReview.TagsOfThirdAnswer = ConfigurationManager.AppSettings["TagsOfThirdAnswer"];
                    _defaultRealtimeReview.CustomTagsOfFirstAnswer = ConfigurationManager.AppSettings["CustomTagsOfFirstAnswer"];
                    _defaultRealtimeReview.CustomTagsOfSecondAnswer = ConfigurationManager.AppSettings["CustomTagsOfSecondAnswer"];
                    _defaultRealtimeReview.CustomTagsOfThirdAnswer = ConfigurationManager.AppSettings["CustomTagsOfThirdAnswer"];
                    _defaultRealtimeReview.BookingId = ConfigurationManager.AppSettings["BookingId"];
                    _defaultRealtimeReview.HotelId = ConfigurationManager.AppSettings["HotelId"];
                    _defaultRealtimeReview.Language = (LanguageType)Enum.Parse(typeof(LanguageType), ConfigurationManager.AppSettings["Languge"] ?? "en_US");
                }
                return _defaultRealtimeReview;
            }
        }
        public static bool Stubbing
        {
            get { return ConfigurationManager.AppSettings["Stubbing"].ConvertToBool(); }
        }
    }
}