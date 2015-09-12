using Periodical.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodical.Web.Models.Admin
{
    public partial class PublicationControlModel
    {
        public int PublicationId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }
        public int TimesInYear { get; set; }
        public int SubscribersCount { get; set; }
        public PublicationControlModel(IPublication publication)
        {
            this.PublicationId = publication.PublicationId;
            this.Title = publication.Title;
            this.Publisher = publication.Publisher;
            this.Price = publication.Price;
            this.TimesInYear = publication.TimesInYear;
            this.SubscribersCount = 0;
        }
    }
}