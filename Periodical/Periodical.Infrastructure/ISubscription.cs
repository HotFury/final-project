using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Infrastructure
{
    public interface ISubscription
    {
        int Id { get; set; }
        int UserId { get; set; }
        int PublicationId { get; set; }
        DateTime StartDate { get; set; }
        DateTime ExpirationDate { get; set; }
        bool PrintVersion { get; set; }
        bool DigitalVersion { get; set; }
        bool Active { get; set; }
    }
}
