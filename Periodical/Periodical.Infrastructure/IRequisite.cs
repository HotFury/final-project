using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Infrastructure
{
    public interface IRequisite
    {
        int Id { get; set; }
        string Title { get; set; }
        int ITN { get; set; }
        int AccountNumber { get; set; }
        string BankName { get; set; }
        int CA { get; set; }
        int BIC { get; set; }
    }
}
