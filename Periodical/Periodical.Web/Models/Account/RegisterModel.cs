using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodical.Web.Models.Account
{
    public partial class RegisterModel
    {
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPasswod { get; set; }

    }
}