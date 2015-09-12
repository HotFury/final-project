using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Periodical.Data.Contexts;
using Periodical.Infrastructure;
using Periodical.Data.Entities;
using System.Collections;

namespace Periodical.BusinessLogic.Repositories
{
    public class AccountRepository : IDisposable 
    {
        private PeriodicalContext periodicalContext;
        private void SaveChanges()
        {
            periodicalContext.SaveChanges();
        }
        public AccountRepository()
        {
            periodicalContext = new PeriodicalContext();

        }
        public IUser GetUser(string nick)
        {
            return periodicalContext.Users.Where(x => x.Nick == nick && !x.Deleted).Select(x => x).FirstOrDefault();
        }
        public bool UserIsActive(string nick)
        {
            return periodicalContext.Users.Where(x => x.Nick == nick.ToLower()).Select(x => x.Active).FirstOrDefault();
        }
        public void AddUser(string nick, string email, string password)
        {
            User newUser = new User();
            newUser.Nick = nick;
            newUser.Email = email;
            newUser.Password = password;
            newUser.Active = true;
            newUser.Deleted = false;
            newUser.CreateDateTime = DateTime.Now;
            periodicalContext.Users.Add(newUser);
            SaveChanges();
        }
        private void AttachUserRole(int userId)
        {
            int roleId = periodicalContext.Roles.Where(x => x.RoleValue == "User").Select(x => x.Id).FirstOrDefault();
            UserInRole newUserInRole = new UserInRole();
            newUserInRole.RoleId = roleId;
            newUserInRole.UserId = userId;
            periodicalContext.UsersInRoles.Add(newUserInRole);
        }
        public void AddUserWithRole(string nick, string email, string password)
        {
            AddUser(nick, email, password);
            int userId = periodicalContext.Users.Where(x => x.Nick == nick).Select(x => x.UserId).FirstOrDefault();
            if (userId != 0)
            {
                AttachUserRole(userId);
            }
            SaveChanges();
        }
        public bool NickCanUse(string nick)
        {
            bool result = periodicalContext.Users.Where(x => x.Nick == nick.ToLower()).Select(x => x).FirstOrDefault() == null;
            return result;
        }
        public bool EmailCanUse(string email)
        {
            return periodicalContext.Users.Where(x => x.Email == email).Select(x => x).FirstOrDefault() == null;
        }
        public string[] GetRolesForUser(string nick)
        {
            User user = periodicalContext.Users.Where(x => x.Nick == nick.ToLower() && !x.Deleted).Select(x => x).FirstOrDefault();
            if (user != null)
            {
                List<string> roles = new List<string>();
                foreach(UserInRole cur in user.UserInRoles)
                {
                    roles.Add(cur.Role.RoleValue);
                }
                return roles.ToArray();
            }
            return new string[] { };
        }
        #region IDisposable
        bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {  
                
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  
        }
        ~AccountRepository()
       {
          Dispose(false);
       }

        #endregion
    }
}
