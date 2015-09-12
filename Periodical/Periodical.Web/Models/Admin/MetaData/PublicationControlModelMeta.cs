using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Periodical.Web.Models.Admin
{
    [MetadataTypeAttribute(typeof(PublicationControlModel.PublicationControlModelMeta))]
    public partial class PublicationControlModel
    {
        internal sealed class PublicationControlModelMeta
        {
            public int PublicationId { get; set; }
            [Display(Name = "Название")]
            public string Title { get; set; }
            [Display(Name = "Издатель")]
            public string Publisher { get; set; }
            [Display(Name = "Цена за номер")]
            public double Price { get; set; }
            [Display(Name = "Период(годовой)")]
            public int TimesInYear { get; set; }
            [Display(Name = "Подписчики")]
            public int SubscribersCount { get; set; }
        }
    }
}