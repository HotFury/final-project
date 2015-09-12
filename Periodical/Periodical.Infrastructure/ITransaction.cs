using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Infrastructure
{
    public interface ITransaction
    {
        int Id { get; set; }
        int UserId { get; set; }
        double Payment { get; set; }
        DateTime CreationDate { get; set; }
        DateTime ComplitionDate { get; set; }
        string Description { get; set; }
        bool CanRollBack { get; set; }
        bool Deleted { get; set; }
    }
}
