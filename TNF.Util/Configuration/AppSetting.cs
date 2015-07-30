using System.Configuration;

namespace TNF.Util.Configuration
{
    public class AppSetting
    {
        public static string MailAddress
        {
            get
            {
                return AppSetting.GetValue("mailAddress");
            }
        }
        public static string MailPassword
        {
            get
            {
                return AppSetting.GetValue("mailPassword");
            }
        }
        public static string MailHost
        {
            get
            {
                return AppSetting.GetValue("mailHost");
            }
        }
        public static int MailPort
        {
            get
            {
                return int.Parse(AppSetting.GetValue("mailPort"));
            }
        }
        public static int CacheMinutes
        {
            get
            {
                int result;
                if (AppSetting.GetValue("cacheMinutes").Length > 0)
                {
                    result = int.Parse(AppSetting.GetValue("cacheMinutes"));
                }
                else
                {
                    result = 5;
                }
                return result;
            }
        }
        public static string DateFormat
        {
            get
            {
                string result = "yyyy-mm-dd";
                if (!string.IsNullOrEmpty(AppSetting.GetValue("dateFormat")))
                {
                    result = AppSetting.GetValue("dateFormat");
                }
                return result;
            }
        }
        public static string GetValue(string key)
        {
            string result;
            if (ConfigurationManager.AppSettings[key] != null)
            {
                result = ConfigurationManager.AppSettings[key].ToString();
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }
    }
}
