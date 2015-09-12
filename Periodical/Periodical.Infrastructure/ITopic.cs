using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Infrastructure
{
    public interface ITopic
    {
        int Id { get; set; }
        string TopicName { get; set; }
    }
}
