namespace PerformanceTuning
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;

    public class PlayWithToList
    {
        public static void SelectAllAdsFromRedmondQuerySlow(AdsDbContext dbContext)
        {
            var sb = new StringBuilder();
            var startTime = DateTime.Now;
            var ads = dbContext.Ads.ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .ToList()
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    id = a.Id,
                    title = a.Title,
                    category = a.CategoryId,
                    town = a.TownId
                })
                .ToList();

            sb.AppendLine("\n---------------------------------------------\n" +
                 "SELECT ALL ADS WITH RANDOM QUERY - SLOW\n---------------------------------------------\n");

            foreach (var ad in ads)
            {
                string category = ad.category != null ? ad.category.ToString() : "N/A";
                string town = ad.town != null ? ad.town.ToString() : "N/A";

                sb.AppendLine(string.Format("Ad: {0}\nTitle: {1}\nCategory: {2}\nTown : {3}\n",
                    ad.id,
                    ad.title,
                    category,
                    town));
            }

            sb.AppendLine(string.Format("---------------------------------------\nTime elapsed: {0}" +
            "\n---------------------------------------\n",
                DateTime.Now - startTime));

            Console.WriteLine(sb);
        }

        public static void SelectAllAdsWithOptimizedQueryFast(AdsDbContext dbContext)
        {
            var sb = new StringBuilder();
            var startTime = DateTime.Now;
            var ads = dbContext.Ads
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    id = a.Id,
                    title = a.Title,
                    category = a.CategoryId,
                    town = a.TownId
                })
                .ToList();

            sb.AppendLine("\n---------------------------------------------\n" +
                 "SELECT ALL ADS WITH OPTIMIZED QUERY - FAST\n---------------------------------------------\n");

            foreach (var ad in ads)
            {
                string category = ad.category != null ? ad.category.ToString() : "N/A";
                string town = ad.town != null ? ad.town.ToString() : "N/A";

                sb.AppendLine(string.Format("Ad: {0}\nTitle: {1}\nCategory: {2}\nTown : {3}\n",
                    ad.id,
                    ad.title,
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
