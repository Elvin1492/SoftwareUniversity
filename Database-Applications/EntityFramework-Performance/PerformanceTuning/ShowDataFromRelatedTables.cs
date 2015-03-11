namespace PerformanceTuning
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;

    public class ShowDataFromRelatedTables
    {
        public static void ListAllAdsWithoutUsingIncludeSlow(AdsDbContext dbContext)
        {
            var sb = new StringBuilder();
            var startTime = DateTime.Now;
            var ads = dbContext.Ads;

            sb.AppendLine("\n---------------------------------------------\n" +
                 "LISTING ADS WITHOUT USING INCLUDE - SLOW\n---------------------------------------------\n");

            foreach (var ad in ads)
            {
                string category = ad.CategoryId != null ? ad.Category.Name : "N/A";
                string town = ad.TownId != null ? ad.Town.Name : "N/A";

                sb.AppendLine(string.Format("Ad: {0}\nTitle: {1}\nStatus: {2}\nCategory: {3}\nTown : {4}\n",
                    ad.Id,
                    ad.Title,
                    ad.AdStatus.Status,
                    category,
                    town));
            }

            sb.AppendLine(string.Format("---------------------------------------\nTime elapsed: {0}" +
            "\n---------------------------------------\n",
                DateTime.Now - startTime));

            Console.WriteLine(sb);
        }

        public static void ListAllAdstUsingIncludeFast(AdsDbContext dbContext)
        {
            var sb = new StringBuilder();
            var startTime = DateTime.Now;
            var ads = dbContext.Ads.Include(a => a.Category).Include(a => a.Town).Include(a => a.AdStatus);

            sb.AppendLine("\n---------------------------------------------\n" +
                 "LISTING ADS USING INCLUDE - FAST\n---------------------------------------------\n");

            foreach (var ad in ads)
            {
                string category = ad.CategoryId != null ? ad.Category.Name : "N/A";
                string town = ad.TownId != null ? ad.Town.Name : "N/A";

                sb.AppendLine(string.Format("Ad: {0}\nTitle: {1}\nStatus: {2}\nCategory: {3}\nTown : {4}\n",
                    ad.Id,
                    ad.Title,
                    ad.AdStatus.Status,
                    category,
                    town));
            }

            sb.AppendLine(string.Format("---------------------------------------\nTime elapsed: {0}" +
            "\n---------------------------------------\n",
                DateTime.Now - startTime));

            Console.WriteLine(sb);
        }
    }
}
