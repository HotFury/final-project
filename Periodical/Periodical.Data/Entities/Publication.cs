using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Periodical.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Periodical.Data.Entities
{
    [Table("Publications")]
    public class Publication : IPublication
    {

        #region IPublication Members
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PublicationId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string LinkToCover { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int TimesInYear { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<TopicToPublication> TopicsToPubication { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Subscribtion> Subsctriptions { get; set; }
        #endregion
    }
}
