using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodical.Web.Models.PersonalArea
{
    [MetadataTypeAttribute(typeof(UserRequsitiesModel.UserRequsitiesModelMeta))]
    public partial class UserRequsitiesModel
    {
        internal sealed class UserRequsitiesModelMeta
        {
            [Required(ErrorMessage = "Введите фамилию")]
            [Display(Name = "Фамилия")]
            [RegularExpression(@"[a-zA-ZА-Я-а-яё]*", ErrorMessage = "Неверный формат фамилии")]
            public string LastName { get; set; }
            [Required(ErrorMessage = "Введите имя")]
            [RegularExpression(@"[a-zA-ZА-Я-а-яё]*", ErrorMessage = "Неверный формат имени")]
            [Display(Name = "Имя")]
            public string FirstName { get; set; }
            [Required(ErrorMessage = "Введите отчество")]
            [RegularExpression(@"[a-zA-ZА-Я-а-яё]*", ErrorMessage = "Неверный формат отчества")]
            [Display(Name = "Отчество")]
            public string MiddleName { get; set; }
            [Required(ErrorMessage = "Введите индекс")]
            [Display(Name = "Почтовый индекс")]
            [RegularExpression(@"[0-9]*", ErrorMessage = "Неверный формат индекса")]
            public int? PostIndex { get; set; }
            [Required(ErrorMessage = "Введите страну")]
            [RegularExpression(@"[a-zA-ZА-Я-а-яё]*", ErrorMessage = "Неверный формат страны")]
            [Display(Name = "Страна")]
            public string Country { get; set; }
            [Required(ErrorMessage = "Введите город")]
            [RegularExpression(@"[a-zA-ZА-Я-а-яё]*", ErrorMessage = "Неверный формат города")]
            [Display(Name = "Город")]
            public string City { get; set; }
            [Display(Name = "Район")]
            [RegularExpression(@"[a-zA-ZА-Я-а-яё]*", ErrorMessage = "Неверный формат района")]
            public string District { get; set; }
            [Required(ErrorMessage = "Введите улицу")]
            [RegularExpression(@"[a-zA-ZА-Я-а-яё]*", ErrorMessage = "Неверный формат улицы")]
            [Display(Name = "Улица")]
            public string Street { get; set; }
            [Required(ErrorMessage = "Введите номер дома")]
            [Display(Name = "Дом")]
            [RegularExpression(@"[0-9]+[\/]*[0-9]*", ErrorMessage = "Неверный формат дома")]
            public string Building { get; set; }
            [Display(Name = "Кв.")]
            [RegularExpression(@"[0-9]*", ErrorMessage = "Неверный формат квартиры")]
            public string Room { get; set; }
            [Display(Name = "Телефон")]
            [RegularExpression(@"[+]*[0-9]+",ErrorMessage = "Неверный формат телефона")]
            public string Phone { get; set; }
        }
    }
}