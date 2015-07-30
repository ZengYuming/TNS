using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNS.Util.Language
{
    public class LanguageHelper
    {
        public static int GetSiteId(TNS.Metadata.LanguageType langugeType)
        {
            switch (langugeType)
            {
                case TNS.Metadata.LanguageType.Danish: return 67;
                case TNS.Metadata.LanguageType.German: return 6;
                case TNS.Metadata.LanguageType.English_US: return 1;
                case TNS.Metadata.LanguageType.English_UK: return 18;
                //case TNS.Metadata.LangugeType.en_AU: return 25;
                //case TNS.Metadata.LangugeType.en_PH: return 68;
                //case TNS.Metadata.LangugeType.es_AR: return 70;
                case TNS.Metadata.LanguageType.Spanish: return 9;
                //case TNS.Metadata.LangugeType.en_CA: return 4;
                //case TNS.Metadata.LangugeType.fr_CA: return 4;
                case TNS.Metadata.LanguageType.French: return 20;
                case TNS.Metadata.LanguageType.Finnish: return 73;
                case TNS.Metadata.LanguageType.Italian: return 8;
                //case TNS.Metadata.LangugeType.id_ID: return 61;
                case TNS.Metadata.LanguageType.Japanese: return 28;
                case TNS.Metadata.LanguageType.Korean: return 16;
                case TNS.Metadata.LanguageType.Norwegian: return 66;
                case TNS.Metadata.LanguageType.Nederlands: return 11;
                //case TNS.Metadata.LangugeType.ms_MY: return 15;
                case TNS.Metadata.LanguageType.Portuguese: return 69;
                case TNS.Metadata.LanguageType.Swedish: return 65;
                case TNS.Metadata.LanguageType.Thailand: return 17;
                case TNS.Metadata.LanguageType.Vietnamese: return 71;
                case TNS.Metadata.LanguageType.Taiwan: return 62;
                case TNS.Metadata.LanguageType.Chinese: return 75;
                case TNS.Metadata.LanguageType.Hongkong: return 18;
                default: return 1;
            }
        }

        public static TNS.Metadata.LanguageType GetLanguageText(string locale)
        {
            TNS.Metadata.LocaleType loc;
            if (Enum.TryParse(locale, out loc))
            {
                return (TNS.Metadata.LanguageType)(int)loc;
            }
            return TNS.Metadata.LanguageType.Chinese;
        }
    }
}
