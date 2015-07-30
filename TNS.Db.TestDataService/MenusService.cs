using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNS.Db.TestDataService
{
    public class MenusService
    {
        public static List<SModule> GetModuleList()
        {
            var list = new List<SModule>();
            var module = new SModule();
            module.ModuleId = "1";
            module.ParentId = "0";
            module.ModuleName = "Mock Up Test Data";
            module.LinkUrl = "";
            module.OrderNo = 1;
            module.Icon = "icon-users";
            list.Add(module);

            module = new SModule();
            module.ModuleId = "001";
            module.ParentId = "1";
            module.ModuleName = "Realtime Review List";
            module.LinkUrl = "/RealtimeReview";
            module.OrderNo = 2;
            module.Icon = "icon-users";
            list.Add(module);
            
            return list;
        }
    }
}
