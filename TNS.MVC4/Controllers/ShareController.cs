using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNS.MVC4.Common;
using Framework.Core.Extensions;

namespace TNS.MVC4.Controllers
{
    public class SharedController : Controller
    {
        //
        // GET: /Share/

        public ActionResult Index()
        {
            return View();
        }

        //
        // 导航菜单

        public ActionResult Menus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetMenus()
        {
            //var json = MenuHelper.GetMenus(CurrentUser.UserId).JsonSerialize();
            var json = MenuHelper.GetMenus(null).JsonSerialize();

            return Content(json);
        }
    }
}
