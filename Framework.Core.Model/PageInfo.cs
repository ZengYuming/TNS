using System;

namespace Framework.Core.Model
{
    [Serializable]
    public class PageInfo
    {
        public PageInfo() { }

        public OrderType Order { get; set; }
        public string OrderField { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }
}
