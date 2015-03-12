namespace NewsSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using NewsSystem.Data;
    using NewsSystem.Models;

    public class ConcurrentUpdates
    {
        public static void MakeUpdate()
        {
            var context = new NewsSystemDbContext();
            var news = context.News.FirstOrDefault();

            Console.WriteLine("Text from DB: {0}", news.Content);
            Console.WriteLine("Enter text correction and hit enter:\nUser input:");

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {                   
                    string correctedText = Console.ReadLine();
                                 
                    news.Content = correctedText;
                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    Console.WriteLine("Changes successfully saved in the DB.");
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    Console.Write("Conflict!");

                    MakeUpdate();
                }
            }
        }
    }
}
