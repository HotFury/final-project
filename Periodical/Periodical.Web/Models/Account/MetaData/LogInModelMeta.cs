using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodical.Web.Models.Account
{
    [MetadataTypeAttribute(typeof(LogInModel.LogInModelMeta))]
    public partial class LogInModel
    {
        internal sealed class LogInModelMeta
        {
            [Display(Name="Ник")]
            [Required(ErrorMessage="3аполните это поле")]
            public string Nick { get; set; }
            [Display(Name = "Пароль")]
            [Required(ErrorMessage = "3аполните это поле")]
            public string Password { get; set; }
            [Display(Name = "Запомнить")]
            public bool RememberMe { get; set; }
        }
    }
}