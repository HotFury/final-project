using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Infrastructure
{
    public interface IAccount
    {
        int UserId { get; set; }
        double Balance { get; set; }
        bool Active { get; set; }
    }
}
