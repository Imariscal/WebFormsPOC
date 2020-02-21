namespace NewsFeed.Model
{
    using NewsFeed.Entity.Models;

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class NewsFeedContext : DbContext
    {
        public NewsFeedContext()
            : base("name=NewsFeedModel")
        {

        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }

    }
}


