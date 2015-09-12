using Periodical.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.Data.Entities
{
    [Table("Topics")]
    public class Topic : ITopic
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TopicName { get; set; }
        public virtual ICollection<TopicToPublication> TopicToPublications { get; set; }
    }
}
