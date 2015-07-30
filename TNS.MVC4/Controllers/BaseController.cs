using Framework.Core.Model;

namespace TNS.MVC4.Controllers
{
    public class BaseController : System.Web.Mvc.Controller
    {
        protected MessageInfo Msg
        {
            get;
            set;
        }
    }
}