using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Infrastructure
{
    public interface IPublication
    {
        int PublicationId { get; set; }
        string Title { get; set; }
        string Publisher { get; set; }
        string LinkToCover { get; set; }
        string Description { get; set; }
        double Price { get; set; }
        int TimesInYear { get; set; }
    }
}
