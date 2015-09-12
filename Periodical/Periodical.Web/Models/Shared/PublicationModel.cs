using Periodical.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodical.Web.Models.Shared
{
    public partial class PublicationModel : IPublication
    {
        public int PublicationId { get; set; }
        public string Title { get; set; }
        public string LinkToCover { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Topics { get; set; }
        public List<string> TopicList { get; set; }
        public int TimesInYear { get; set; }
        
        public PublicationModel(IPublication publication, List<string> topicList)
        {
            this.PublicationId = publication.PublicationId;
            this.Title = publication.Title;
            this.LinkToCover = publication.LinkToCover;
            this.Description = publication.Description;
            this.Price = publication.Price;
            this.TimesInYear = publication.TimesInYear;
            this.Publisher = publication.Publisher;
            this.TopicList = new List<string>(topicList);
            this.Topics = String.Empty;
            if (topicList != null)
            {
                foreach (string item in topicList)
                {
                    this.Topics += item + ", ";
                }
            }
        }
        public PublicationModel()
        {

        }
    }
}