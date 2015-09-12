using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Data.Entities
{
    [Table("TopicsToPublications")]
    public class TopicToPublication
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int PublicationId { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual Publication Publication { get; set; }
    }
}
