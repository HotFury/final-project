using Periodical.Data.Contexts;
using Periodical.Data.Entities;
using Periodical.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodical.BusinessLogic.Repositories
{
    public class PublicationRepository
    {
        private PeriodicalContext periodicalContext = new PeriodicalContext();
        public List<IPublication> AllPublication
        {
            get
            {
                List<Publication> allPublications = periodicalContext.Publications.Where(x => !x.Deleted).Select(x => x).ToList();
                List<IPublication> result = new List<IPublication>(allPublications);
                return result;

            }
        }

        private void SaveChanges()
        {
            periodicalContext.SaveChanges();
        }
        public void SavePublication(IPublication publication, string[] topics)
        {
            Publication newPublication = new Publication();
            newPublication.PublicationId = publication.PublicationId;
            newPublication.LinkToCover = publication.LinkToCover;
            newPublication.Title = publication.Title;
            newPublication.Description = publication.Description;
            newPublication.Price = publication.Price;
            newPublication.Deleted = false;
            newPublication.TimesInYear = publication.TimesInYear;
            newPublication.Publisher = publication.Publisher;
            UpdateTopics(topics);
            if (newPublication.PublicationId == 0)
            {
                AddPublication(newPublication);
                AddTopicsToPublications(topics);
            }
            else
            {
                UpdatePublication(newPublication);
                UpdateTopicsToPublications(topics, newPublication.PublicationId);
            }
            
            
        }
        private void UpdateTopics(string[] topics)
        {
            foreach (string item in topics)
            {
                bool topicExist = periodicalContext.Topics.Where(x => x.TopicName == item).Select(x => x).FirstOrDefault() != null;
                if (!topicExist &&  item != String.Empty)
                {
                    Topic newTopic = new Topic();
                    newTopic.TopicName = item;
                    periodicalContext.Topics.Add(newTopic);
                }
            }
            SaveChanges();
        }
        private void AddPublication(Publication newPublication)
        {
            periodicalContext.Publications.Add(newPublication);
            SaveChanges();
        }
        private void UpdatePublication(Publication publication)
        {
            periodicalContext.Entry(publication).State = EntityState.Modified;
            SaveChanges();
        }
        private void AddTopicsToPublications(string[] topics)
        {
            int publicationId = periodicalContext.Publications.OrderByDescending(x => x.PublicationId).First().PublicationId;
            List<TopicToPublication> topicsToPublication = new List<TopicToPublication>();
            foreach (string item in topics)
            {
                TopicToPublication newTopicToPublication = new TopicToPublication();
                newTopicToPublication.PublicationId = publicationId;
                newTopicToPublication.TopicId = periodicalContext.Topics.Where(x => x.TopicName == item).Select(x => x.Id).FirstOrDefault();
                periodicalContext.TopicsToPublications.Add(newTopicToPublication);
            }
            SaveChanges();
        }
        private void UpdateTopicsToPublications(string[] topics, int publicationId)
        {
            List<int> oldTopicsId = periodicalContext.TopicsToPublications.Where(x => x.PublicationId == publicationId).Select(x => x.TopicId).ToList();
            List<int> newTopicsId = new List<int>();
            foreach(string item in topics)
            {
                int id = periodicalContext.Topics.Where(x => x.TopicName == item).Select(x => x.Id).FirstOrDefault();
                newTopicsId.Add(id);
            }
            //delete topics
            foreach(int id in oldTopicsId)
            {
                if (!newTopicsId.Contains(id))
                {
                    TopicToPublication forDelete = periodicalContext.TopicsToPublications.Where(x => x.TopicId == id && x.PublicationId == publicationId).Select(x => x).FirstOrDefault();
                    periodicalContext.TopicsToPublications.Remove(forDelete);
                }
            }
            //add new
            foreach(int id in newTopicsId)
            {
                if (!oldTopicsId.Contains(id))
                {
                    TopicToPublication forAdd = new TopicToPublication();
                    forAdd.PublicationId = publicationId;
                    forAdd.TopicId = id;
                    periodicalContext.TopicsToPublications.Add(forAdd);
                }
            }
            SaveChanges();
        }
        public List<string> GetTopicsToPublication(int publicationId)
        {
            List<string> result = new List<string>();
            Publication publication = periodicalContext.Publications.Where(x => x.PublicationId == publicationId).Select(x => x).FirstOrDefault();
            if (publication != null)
            {
                foreach (TopicToPublication item in publication.TopicsToPubication)
                {
                    result.Add(item.Topic.TopicName);
                }
            }
            return result;
        }
        public IPublication GetPublicationById(int id)
        {
            return periodicalContext.Publications.Where(x => x.PublicationId == id).Select(x => x).FirstOrDefault();
        }
        public void DeletePublication(int id)
        {
            Publication publicationForDelete = periodicalContext.Publications.Where(x => x.PublicationId == id).Select(x => x).FirstOrDefault();
            publicationForDelete.Deleted = true;
            periodicalContext.Entry(publicationForDelete).State = EntityState.Modified;
            SaveChanges();
        }
        
    }
}
