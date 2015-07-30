using System;

namespace Framework.Core.Model
{
    [Serializable]
    public class PageInfo
    {
        private int pageSize;
        private int pageIndex;
        public int PageSize
        {
            get
            {
                if (this.pageSize > 0)
                {
                    return this.pageSize;
                }
                return 10;
            }
            set
            {
                this.pageSize = ((value <= 0) ? 10 : value);
            }
        }
        public int PageIndex
        {
            get
            {
                if (this.pageIndex > 0)
                {
                    return this.pageIndex;
                }
                return 1;
            }
            set
            {
                this.pageIndex = ((value <= 0) ? 1 : value);
            }
        }
        public string OrderField
        {
            get;
            set;
        }
        public OrderEnum Order
        {
            get;
            set;
        }
        public int Total
        {
            get;
            set;
        }
    }
}
