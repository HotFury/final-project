using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Periodical.Web.Filters
{
    public class ForAdmin : FilterAttribute, IActionFilter
    {

        #region IActionFilter Members

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated || !Roles.IsUserInRole("Admin"))
            {
                throw new HttpException(404, "");
            }
        }

        #endregion
    }
}