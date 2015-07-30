using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TF.Utility.Cache
{
    public interface ICacheService
    {
        void Clear();
        bool Contains(object key);
        object Get(object key);
        void Add(object key, object obj);
        void Add(object key, object obj, int cacheMinutes);
        void Delete(object key);
        void DeleteBatch(string name);
    }
}
