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
    [Table("Comments")]
    public class Comment : IComment
    {

        #region IComment Members
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PublicationId { get; set; }
        public string CommentText { get; set; }
        public DateTime LastDateTime { get; set; }
        public virtual Publication Publication { get; set; }
        public virtual User User { get; set; }
        #endregion
    }
}
