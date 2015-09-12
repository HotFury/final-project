using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Periodical.Infrastructure;
using Periodical.BusinessLogic.Infrastructure;
namespace Periodical.Web.Models.PersonalArea
{

    public partial class UserRequsitiesModel : IUserRequisitiesDetail
    {
        private enum fullAddress { street, building, room, addressIsFull }
        public bool exist;
        public string Nick { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int? PostIndex { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Room { get; set; }
        public string Phone { get; set; }
        public UserRequsitiesModel(IUsersRequisite requisities, string nick)
        {
            this.Nick = nick;
            if (requisities != null)
            {
                exist = true;
                this.Country = requisities.Country;
                this.City = requisities.City;
                this.District = requisities.District;
                this.FirstName = requisities.FirstName;
                this.LastName = requisities.LastName;
                this.MiddleName = requisities.MiddleName;
                this.Phone = requisities.Phone;
                if (requisities.PostIndex == 0)
                    this.PostIndex = null;
                else
                {
                    this.PostIndex = requisities.PostIndex;
                }
                if (requisities.Address != null)
                {
                    string[] address = requisities.Address.Split(' ');
                    if (address != null)
                    {
                        this.Street = address[(int)fullAddress.street];
                        this.Building = address[(int)fullAddress.building];
                        if (address.Length == (int)fullAddress.addressIsFull)
                        {
                            this.Room = address[(int)fullAddress.room];
                        }
                    }
                }

            }
            else
            {
                exist = false;
            }
        }
        public UserRequsitiesModel()
        {

        }
    }
}