using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LayuiNetCoreDemo.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var host = context.HttpContext.Request.Host;
            if (host.Host == "localhost") { }
            else if (host.Host == "127.0.0.1") { }
            else if (host.Host != "jalan.wang")
            {
                host = new Microsoft.AspNetCore.Http.HostString("jalan.wang");
            }

            base.OnActionExecuting(context);
        }
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var host = context.HttpContext.Request.Host;
            return base.OnActionExecutionAsync(context, next);
        }
    }
}