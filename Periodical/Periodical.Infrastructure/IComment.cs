using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Infrastructure
{
    public interface IComment
    {
        int Id { get; set; }
        int UserId { get; set; }
        int PublicationId { get; set; }
        string CommentText { get; set; }
        DateTime LastDateTime { get; set; }
    }
}
