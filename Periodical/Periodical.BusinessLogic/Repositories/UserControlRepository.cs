using Periodical.Data.Contexts;
using Periodical.Data.Entities;
using Periodical.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.BusinessLogic.Repositories
{
    public class UserControlRepository
    {
        private PeriodicalContext periodicalContext = new PeriodicalContext();
        public List<IUser> AllUsers
        {
            get
            {
                List<User> allUsers = periodicalContext.Users.Where(x => !x.Deleted).Select(x => x).ToList();
                List<IUser> result = new List<IUser>(allUsers);
                return result;
            }
        }
        private void SaveChanges()
        {
            periodicalContext.SaveChanges();
        }

        public IUser GetUser(int id)
        {
            return periodicalContext.Users.Where(x => x.UserId == id).Select(x => x).FirstOrDefault();
        }
        public IUsersRequisite GetUserDetails(int userId)
        {
            return periodicalContext.UsersRequisites.Where(x => x.UserId == userId).Select(x => x).FirstOrDefault();
        }
        public void ToggleActive(int id)
        {
            User editUser = periodicalContext.Users.Where(x => x.UserId == id).Select(x => x).FirstOrDefault();
            editUser.Active = !editUser.Active;
            periodicalContext.Entry(editUser).State = EntityState.Modified;
            SaveChanges();
        }
        public void DeleteUser(int id)
        {
            User userForDelete = periodicalContext.Users.Where(x => x.UserId == id).Select(x => x).FirstOrDefault();
            userForDelete.Deleted = true;
            periodicalContext.Entry(userForDelete).State = EntityState.Modified;
            SaveChanges();
        }
        public string[] GetUserRoles(int userId)
        {
            List<string> roles = new List<string>();
            List<UserInRole> userInRoles = new List<UserInRole>();
            User user = periodicalContext.Users.Where(x => x.UserId == userId).Select(x => x).FirstOrDefault();
            if (user != null)
            {
                userInRoles = user.UserInRoles.ToList();
            }
            foreach(UserInRole item in userInRoles)
            {
                roles.Add(item.Role.RoleValue);
            }
            return roles.ToArray();
        }
        public int GetUserId(string userName)
        {
            return periodicalContext.Users.Where(x => x.Nick == userName).Select(x => x.UserId).FirstOrDefault();
        }
        public void AttachRole(string userName, string role)
        {
            int userId = GetUserId(userName);
            if (userId != 0)
            {
                int roleId = periodicalContext.Roles.Where(x => x.RoleValue == role).Select(x => x.Id).FirstOrDefault();
                UserInRole newUserInRole = new UserInRole();
                newUserInRole.RoleId = roleId;
                newUserInRole.UserId = userId;
                periodicalContext.UsersInRoles.Add(newUserInRole);
                SaveChanges();
            }
        }
        public void DeAttachRole(string userName, string role)
        {
            int userId = GetUserId(userName);
            if (userId != 0)
            {
                int roleId = periodicalContext.Roles.Where(x => x.RoleValue == role).Select(x => x.Id).FirstOrDefault();
                UserInRole newUserInRole = periodicalContext.UsersInRoles.Where(x => x.RoleId == roleId).Select(x => x).FirstOrDefault();
                periodicalContext.UsersInRoles.Remove(newUserInRole);
                SaveChanges();
            }
        }
    }
}
