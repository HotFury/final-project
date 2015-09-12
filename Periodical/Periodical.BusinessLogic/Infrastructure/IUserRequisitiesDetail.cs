using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.BusinessLogic.Infrastructure
{
    public interface IUserRequisitiesDetail
    {
        string Nick { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        int? PostIndex { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string District { get; set; }
        string Street { get; set; }
        string Building { get; set; }
        string Room { get; set; }
        string Phone { get; set; }
    }
}
