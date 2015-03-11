namespace PerformanceTuning
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;

    public class SelectEverythingVsSelectCertainColumns
    {
        public static void SelectEverythingSlow(AdsDbContext dbContext)
        {
            var sb = new StringBuilder();
            var startTime = DateTime.Now;
            var ads = dbContext.Ads;

            sb.AppendLine("\n---------------------------------------------\n" +
                 "SELECT EVERYTHING FROM ADS - SLOW\n---------------------------------------------\n");

            foreach (var ad in ads)
            {
                sb.AppendLine(string.Format("Ad Title: {0}", ad.Title));
            }

            sb.AppendLine(string.Format("---------------------------------------\nTime elapsed: {0}" +
            "\n---------------------------------------\n",
                DateTime.Now - startTime));

            Console.WriteLine(sb);
        }

        public static void SelectCertainCoumnsFast(AdsDbContext dbContext)
        {
            var sb = new StringBuilder();
            var startTime = DateTime.Now;
            var adsTitles = dbContext.Ads.Select(a => a.Title);

            sb.AppendLine("\n---------------------------------------------\n" +
                 "SELECT CERTAIN COLUMNS FROM ADS - FAST\n---------------------------------------------\n");

            foreach (var title in adsTitles)
            {
                sb.AppendLine(string.Format("Ad Title: {0}", title));
            }

            sb.AppendLine(string.Format("---------------------------------------\nTime elapsed: {0}" +
            "\n---------------------------------------\n",
                DateTime.Now - startTime));

            Console.WriteLine(sb);
        }
    }
}
