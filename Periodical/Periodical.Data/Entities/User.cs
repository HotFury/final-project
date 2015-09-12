using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Periodical.Infrastructure;

namespace Periodical.Data.Entities
{
    [Table("Users")]
    public class User : IUser
    {
        #region IUser Members
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<Subscribtion> Subscriptions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<UserRequisite> UserRequisite { get; set; }
        #endregion

    }
}
