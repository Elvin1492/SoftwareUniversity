namespace NewsSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;

    using NewsSystem.Data;
    using NewsSystem.Data.Migrations;
    using NewsSystem.Data.Migrations.Repositories;
    using NewsSystem.Models;

    public class ConsoleClient
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsSystemDbContext, Configuration>());
            var dbContext = new NewsSystemDbContext();

            // Activating database
            Console.WriteLine("Connecting to database ...\n");
            dbContext.News.Count();

            Console.WriteLine("Application started.\n");
            ConcurrentUpdates.MakeUpdate();           
        }
    }
}
