using Periodical.BusinessLogic.Infrastructure;
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
    public class UserRequisitiesRepository
    {
        private PeriodicalContext periodicalContext = new PeriodicalContext();
        private void SaveChanges()
        {
            periodicalContext.SaveChanges();
        }
        public IUsersRequisite GetUserRequisites(string nick)
        {
            UserRequisite requisites = new UserRequisite();
            User user = periodicalContext.Users.Where(x => x.Nick == nick.ToLower()).Select(x => x).FirstOrDefault();
            if(user != null)
            {
                requisites = user.UserRequisite.FirstOrDefault();
            }
            return requisites;
        }
        public void ManageRequisities(IUserRequisitiesDetail requisities)
        {
            UserRequisite userRequisities = new UserRequisite();
            userRequisities.UserId = periodicalContext.Users.Where(x => x.Nick == requisities.Nick).Select(x => x.UserId).FirstOrDefault();
            if (userRequisities.UserId != 0)
            {
                userRequisities.LastName = requisities.LastName;
                userRequisities.FirstName = requisities.FirstName;
                userRequisities.MiddleName = requisities.MiddleName;
                userRequisities.PostIndex = (int)requisities.PostIndex;
                userRequisities.Country = requisities.Country;
                userRequisities.City = requisities.City;
                userRequisities.District = requisities.District;
                userRequisities.Address = requisities.Street + " " + requisities.Building + " " + requisities.Room;
                userRequisities.Phone = requisities.Phone;
                userRequisities.Id = periodicalContext.UsersRequisites.Where(x => x.UserId == userRequisities.UserId).Select(x => x.Id).FirstOrDefault();
                if (userRequisities.Id == 0)
                {
                    periodicalContext.UsersRequisites.Add(userRequisities);
                }
                else
                {
                    
                    periodicalContext.Entry(userRequisities).State = EntityState.Modified;
                }
                SaveChanges();
            }
        }
    }
}
