using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNS.Metadata.Query
{
    public class QRealtimeReview
    {
        public int hotelId { get; set; }
        public int itemsCount { get; set; }
        public string checkin { get; set; }
        public string checkout { get; set; }
        public bool isDateRange { get; set; }
    }
}
