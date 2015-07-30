using System;
using System.Collections.Generic;

namespace TNS.Db
{
    public class Salesman
    {
        public Salesman() { }
        //GUID
        public string SalesmanId { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string AliAccount { get; set; }

        public List<QQ> QQList { get; set; }
    }
}
