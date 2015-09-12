using Periodical.BusinessLogic.Repositories;
using Periodical.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Periodical.Web.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (AccountRepository repository = new AccountRepository())
            {
                try
                {
                    IUser user = repository.GetUser(username);
                    if (user != null)
                    {
                        roles = repository.GetRolesForUser(username);
                    }
                }
                catch
                {
                    roles = new string[] { };
                }
            }
            return roles;
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            bool result = false;
            using(AccountRepository repository = new AccountRepository())
            {
                try
                {
                    IUser user = repository.GetUser(username);
                    if (user != null)
                    {
                        string[] roles = GetRolesForUser(username);
                        result = roles.Contains(roleName);
                    }
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
 
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
#region NotNeed
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
 
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
 
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
 
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
 
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
 
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
#endregion
    }
}