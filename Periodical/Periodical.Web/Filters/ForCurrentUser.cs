using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Periodical.Web.Filters
{
    public class ForCurrentUser : FilterAttribute, IActionFilter
    {
        #region IActionFilter Members
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userName = filterContext.HttpContext.User.Identity.Name.ToLower();
            string url = filterContext.HttpContext.Request.Url.ToString();
            Regex regex = new Regex(@"[a-zA-Z0-9]+$");
            Match match = regex.Match(url);
            string id = match.Value.ToLower() ;
            if (userName != id)
            {
                throw new HttpException(404, "");
            }
        }

        #endregion
    }
}