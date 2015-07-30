namespace TNS.Metadata
{
    public enum MessageType
    {
        Info,
        Warn,
        Error
    }

    public enum AnswerType : int
    {
        None = -1,
        Happy = 0,
        Sad = 1
    }

    public enum LocaleType
    {
        en_US = 1033,
        en_HK = 2057,
        es_ES = 3082,
        it_IT = 1040,
        fr_FR = 1036,
        de_DE = 1031,
        ja_JP = 1041,
        zh_CN = 2052,
        zh_TW = 1028,
        zh_HK = 3076,
        nl_NL = 1043,
        sv_SE = 1053,
        nb_NO = 1044,
        pt_BR = 1046,
        da_DK = 1030,
        ko_KR = 1042,
        vi_VN = 1066,
        th_TH = 1054,
        fi_FI = 1035,
        en_AU = 3081,
        en_PH = 13321,
        es_AR = 11274,
        en_CA = 4105,
        fr_CA = 3084,
        id_ID = 1057,
        ms_MY = 1086,
    }

    public enum LanguageType : int
    {
        English_US = 1033,//en_US     
        English_UK = 2057,//en_HK     
        Spanish = 3082,//es_ES        
        Italian = 1040,//it_IT        
        French = 1036,//fr_FR         
        German = 1031,//de_DE         
        Japanese = 1041,//ja_JP       
        Chinese = 2052,//zh_CN        
        Taiwan = 1028,//zh_TW         
        Hongkong = 3076,//zh_HK       
        Nederlands = 1043,//nl_NL     
        Swedish = 1053,//sv_SE        
        Norwegian = 1044,//nb_NO      
        Portuguese = 1046,//pt_BR     
        Danish = 1030,//da_DK         
        Korean = 1042,//ko_KR         
        Vietnamese = 1066,//vi_VN     
        Thailand = 1054,//th_TH       
        Finnish = 1035,//fi_FI
    }
}
