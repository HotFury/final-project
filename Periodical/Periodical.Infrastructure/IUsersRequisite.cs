using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Infrastructure
{
    public interface IUsersRequisite
    {
        int Id { get; set; }
        int UserId { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string District { get; set; }
        string Address { get; set; }
        int PostIndex { get; set; }
        string Phone { get; set; }
    }
}
