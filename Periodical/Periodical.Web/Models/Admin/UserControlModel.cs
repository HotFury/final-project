using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Periodical.Infrastructure;

namespace Periodical.Web.Models.Admin
{
    public partial class UserControlModel
    {
        public int UserId {get; set;}
        public string Nick { get; set; }
        public string Email { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool Active { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string[] Roles { get; set; }
        public UserControlModel(IUser user, IUsersRequisite more, string[] roles)
        {
            this.UserId = user.UserId;
            this.Nick = user.Nick;
            this.Email = user.Email;
            this.CreateDateTime = user.CreateDateTime;
            this.Active = user.Active;
            if (more != null)
            {   
                this.LastName = more.LastName;
                this.FirstName = more.FirstName;
                this.MiddleName = more.MiddleName;
            }
            this.Roles = roles;
        }
    }
}