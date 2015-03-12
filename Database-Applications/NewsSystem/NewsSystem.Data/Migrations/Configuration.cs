namespace NewsSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using NewsSystem.Models;
    using NewsSystem.Data.Migrations.Repositories;

    public sealed class Configuration : DbMigrationsConfiguration<NewsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "NewsSystem.Data.NewsSystemDbContext";
        }

        protected override void Seed(NewsSystemDbContext context)
        {
            this.SeedNews(context);
            base.Seed(context);
        }

        private void SeedNews(INewsSystemDbContext context)
        {
            if (context.News.Any())
            {
                return;
            }

            var entityFrameworkNews = new News
            {
                Content = "EF 7 Beta To Be Released in May 2016",
            };

            var newsDbContext = new GenericRepository<News>(context);
            newsDbContext.Add(entityFrameworkNews);
            newsDbContext.SaveChanges();
        }
    }
}
