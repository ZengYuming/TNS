using System;
using System.Collections;
using Framework.Core.Extensions;

namespace TNS.MVC4.Common
{
    public static class PagingHelper//<T> where T:class 
    {
        public static string ConvertJson(IEnumerable rows, int total)
        {
            var pageList = new PageJson(rows, total);
            return pageList.JsonSerialize();
        }
    }

    [Serializable]
    public class PageJson//<T> where T:class 
    {
        public int total { get; set; }
        public IEnumerable rows { get; set; }

        public PageJson(IEnumerable rows, int total)
        {
            this.rows = rows;
            this.total = total;
        }
    }
}