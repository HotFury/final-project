using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Infrastructure
{
    public interface IUser
    {
        int UserId { get; set; }
        string Nick { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        DateTime CreateDateTime { get; set; }
        bool Active { get; set; }
        bool Deleted { get; set; }
    }
}
