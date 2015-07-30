using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNS.Metadata;

namespace TNS.MVC4.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            //AddAccountNameToCookies();
            return Content("");
        }


        private void AddAccountNameToCookies(string name)
        {
            const int maxCount = 5;
            HttpCookie requestCookie = Request.Cookies.Get(Const.CookieName_LoginAccountList);
            HttpCookie responseCookie = Response.Cookies.Get(Const.CookieName_LoginAccountList);
            if (requestCookie == null)
            {
                var cookie = new HttpCookie(Const.CookieName_LoginAccountList, name);
                cookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cookie);
            }
            else
            {

                string[] origalNameArray = requestCookie.Value.Split(',');

                for (int i = 0; i < maxCount - 1; i++)
                {
                    if (i >= origalNameArray.Length)
                    { break; }
                    if (!name.Contains(origalNameArray[i]))
                    {
                        name += "," + origalNameArray[i];
                    }
                }

                responseCookie.Value = name;
                responseCookie.Expires = DateTime.Now.AddYears(1);
            }
        }
    }
}
