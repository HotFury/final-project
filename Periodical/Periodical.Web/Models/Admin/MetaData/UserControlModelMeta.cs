using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodical.Web.Models.Admin
{
    [MetadataTypeAttribute(typeof(UserControlModel.UserModelMeta))]
    public partial class UserControlModel
    {
        internal sealed class UserModelMeta
        {
            public int UserId { get; set; }
            [Display(Name = "Ник")]
            public string Nick { get; set; }
            [Display(Name = "E-mail")]
            public string Email { get; set; }
            [Display(Name = "Дата создания")]
            public DateTime CreateDateTime { get; set; }
            [Display(Name = "Доступ")]
            public bool Active { get; set; }
            [Display(Name = "Фамилия")]
            public string LastName { get; set; }
            [Display(Name = "Имя")]
            public string FirstName { get; set; }
            [Display(Name = "Отчество")]
            public string MiddleName { get; set; }
            public string[] Roles { get; set; }
        }
    }
}