using KissLog;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC.Extensions
{
    public class AuditoriaFilter : IActionFilter
    {

        private readonly ILogger _logger;

        public AuditoriaFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var message = context.HttpContext.User.Identity.Name + "Acessou: " +
                    context.HttpContext.Request;

                _logger.Info(message);
            }
            else
            {
                var message = context.HttpContext.User.Identity.Name + "Acessou: " +
                   context.HttpContext.Request;

                _logger.Info(message);

            }
        }
    }
}
