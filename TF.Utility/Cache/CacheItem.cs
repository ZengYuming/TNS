using System;

namespace TF.Utility.Cache
{
   public class CacheItem
    {
        private object key;
        private int cacheMinutes;
        private int queryCount;
        private string fullName;
        private DateTime createTime;
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
            }
        }
        public int QueryCount
        {
            get
            {
                return this.queryCount;
            }
            set
            {
                this.queryCount = value;
            }
        }
        public int CacheMinutes
        {
            get
            {
                return this.cacheMinutes;
            }
            set
            {
                this.cacheMinutes = value;
            }
        }
        public object Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
            }
        }
        public DateTime CreateTime
        {
            get
            {
                return this.createTime;
            }
            set
            {
                this.createTime = value;
            }
        }
    }
}
