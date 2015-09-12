using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodical.Web.Models.Account
{
    [MetadataTypeAttribute(typeof(RegisterModel.RegisterModelMeta))]
    public partial class RegisterModel
    {
        internal sealed class RegisterModelMeta
        {
            [Required(ErrorMessage="Поле обязательно для заполнения")]
            [Display(Name="Ник")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Ник должен быть от 3 до 50 символов")]
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "используйте только латинские буквы и/или цифры")]
            public string Nick { get; set; }
            [Required(ErrorMessage = "Поле обязательно для заполнения")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "не является E-mail адресом")]
            [Display(Name="E-mail")]
            public string Email { get; set; }
            [DataType(DataType.Password)]
            [Display(Name="Пароль")]
            [StringLength(100, ErrorMessage = "{0} должен состоять хотя бы из {2} символов.", MinimumLength = 6)]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Display(Name="Подтверждение")]
            [Compare("Password", ErrorMessage = "Пароль и подтверждение не совпадают")]
            public string ConfirmPasswod { get; set; }
        }
    }
}