using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NuGet.Protocol.Plugins;

namespace LibraryManagement.ActionFilter
{
    public class UserActionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Controller is Controller controller)
            {
                controller.ViewBag.login = filterContext.HttpContext.Session.GetString("login");
                controller.ViewBag.isSuperUser = filterContext.HttpContext.Session.GetString("isSuperUser");
            }
        }
    }
}
