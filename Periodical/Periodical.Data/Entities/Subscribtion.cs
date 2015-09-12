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
    [Table("Subscriptions")]
    public class Subscribtion : ISubscription
    {

        #region ISubscription Members

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PublicationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool PrintVersion { get; set; }
        public bool DigitalVersion { get; set; }
        public bool Active { get; set; }
        public virtual Publication Publication { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}
