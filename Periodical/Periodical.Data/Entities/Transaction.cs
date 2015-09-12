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
    [Table("Transactions")]
    public class Transaction : ITransaction
    {

        #region ITransaction Members
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Payment { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ComplitionDate { get; set; }
        public string Description { get; set; }
        public bool CanRollBack { get; set; }
        public bool Deleted { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}
