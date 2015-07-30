using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TNS.MVC4.Controllers
{
    [Authorize]
    public class AuthorizedController : BaseController
    {
        //public SUser CurrentUser
        //{
        //    get
        //    {
        //        return ((FormsIdentity)(HttpContext.User.Identity)).Ticket.UserData.JsonDeserialize<SUser>();
        //    }
        //}

        //public string CustomerId
        //{
        //    get { return CurrentUser.CustomerId; }
        //}

        //public string CompanyId
        //{
        //    get { return CurrentUser.CompanyId; }
        //}
    }
}
