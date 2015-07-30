using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNS.Db.TestDataService;
using TNS.Metadata;

namespace TNS.MVC4.Common
{
    public class MenuHelper
    {
        public static List<Menu> GetMenus(string userId)
        {
            //var list = Factory.RoleInstance.GetModuleList(userId).ToList();
            var list = MenusService.GetModuleList().ToList();
            var menuList = new List<Menu>();
            int index = 1;
            foreach (var item in list.Where(o => o.ParentId == "0").OrderBy(o => o.OrderNo))
            {
                menuList.Add(new Menu
                {
                    menuid = index++,
                    menuname = item.ModuleName,
                    url = item.LinkUrl,
                    icon = item.Icon,
                    menus = list.Where(o => o.ParentId == item.ModuleId).OrderBy(o => o.OrderNo).Select(o => new Menu
                    {
                        menuid = index++,
                        menuname = o.ModuleName,
                        url = o.LinkUrl,
                        icon = o.Icon,
                    }).ToList()
                });
            }
            return menuList;
        }
    }
}