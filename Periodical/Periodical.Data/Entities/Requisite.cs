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
    [Table("Requisites")]
    public class Requisite : IRequisite
    {
        #region IRequisites Members
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ITN { get; set; }
        public int AccountNumber { get; set; }
        public string BankName { get; set; }
        public int CA { get; set; }
        public int BIC { get; set; }
        #endregion
    }
}
