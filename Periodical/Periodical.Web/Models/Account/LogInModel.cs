using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodical.Web.Models.Account
{
    public partial class LogInModel
    {
        public string Nick { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}