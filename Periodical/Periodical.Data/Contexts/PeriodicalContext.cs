using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Periodical.Data.Entities;

namespace Periodical.Data.Contexts
{
    public class PeriodicalContext :DbContext
    {
        public PeriodicalContext()
            : base("PeriodicalContext")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Requisite> Requisites { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subscribtion> Subscriptions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicToPublication> TopicsToPublications { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInRole> UsersInRoles { get; set; }
        public DbSet<UserRequisite> UsersRequisites { get; set; }
    }
}
