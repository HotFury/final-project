using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodical.Web.Models.Shared
{
    [MetadataTypeAttribute(typeof(PublicationModel.PublicationModelMeta))]
    public partial class PublicationModel
    {
        internal sealed class PublicationModelMeta
        {
            public int PublicationId { get; set; }
            [Display(Name = "Название")]
            [Required(ErrorMessage="Обязательно введите название")]
            public string Title { get; set; }
            [Display(Name = "Издатель")]
            [Required(ErrorMessage = "Обязательно заполните издателя")]
            public string Publisher { get; set; }
            public string LinkToCover { get; set; }
            [Display(Name = "Описание")]
            public string Description { get; set; }
            [Display(Name = "Цена за номер")]
            [Required(ErrorMessage = "Введите цену")]
            public double? Price { get; set; }
            [Display(Name = "Темы")]
            [Required(ErrorMessage = "Введите подходящие темы")]
            public string Topics { get; set; }
            [Display(Name = "Период")]
            [Required(ErrorMessage = "Введите период")]
            public int? TimesInYear { get; set; }
        }   
    }
}