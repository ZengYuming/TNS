using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mockata.common
{
    public class RealtimeReviewTagsHelper
    {
        private static Dictionary<int, string> _tags = new Dictionary<int, string>() {
       {0	,"Other"},
       {1	,"Staff"},
       {10	,"Nice bed"	},{11	,"Clean"	},{12	,"Renovated new"	
},{13	,"Great amenities"	
},{14	,"Spacious"	
},{15	,"Quiet"	
},{16	,"Clean Bathroom"	
},{17	,"Terrible bed"	
},{18	,"Dirty"	
},{19	,"Old, outdated"	
},{2	,"Lobby"	
},{20	,"Few amenities"	
},{21	,"Small"	
},{22	,"Noisy"	
},{23	,"Dirty Bathroom"	
},{24	,"Safe"	
},{25	,"Great Shopping"	
},{26	,"Good eats"	
},{27	,"Transportation"
},{28	,"Walkable"	
},{29	,"Easy parking"	
},{3	,"Quick"	
},{30	,"Dangerous"	
},{31	,"No dining"	
},{32	,"No transportation"	
},{33	,"Run-down"	
},{34	,"No parking"	
},{4	,"Upgrade"	
},{5	,"Welcome gift"	
},{6	,"Problem with reservation"	
},{7	,"Slow"	
},{8	,"Unexpected fees"	
},{9	,"No perks"	
       }};


        public static string GetTagByKey(int key)
        {
            if (_tags.ContainsKey(key))
            {
                return _tags[key];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
