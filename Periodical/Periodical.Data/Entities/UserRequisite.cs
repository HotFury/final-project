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
    [Table("UserReqisites")]
    public class UserRequisite : IUsersRequisite
    {
        #region IUsersRequisites Members
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int PostIndex { get; set; }
        public string Phone { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}
