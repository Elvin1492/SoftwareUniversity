namespace PerformanceTuning
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    public class ProgramEntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("Connecting to database ...\n-----------------------------------\n");
            var startTime = DateTime.Now;
            var adsDbContext = new AdsDbContext();

            // this is calculated in order to establish conection to the database so the time
            // needed wont't be calcuated in the time tests 
            int adsTotalCount = adsDbContext.Ads.Count();
            Console.WriteLine("Connection took: {0}\n-----------------------------------",
                DateTime.Now - startTime);

            ShowDataFromRelatedTables.ListAllAdsWithoutUsingIncludeSlow(adsDbContext);
            ShowDataFromRelatedTables.ListAllAdstUsingIncludeFast(adsDbContext);
            PlayWithToList.SelectAllAdsFromRedmondQuerySlow(adsDbContext);
            PlayWithToList.SelectAllAdsWithOptimizedQueryFast(adsDbContext);
            SelectEverythingVsSelectCertainColumns.SelectEverythingSlow(adsDbContext);
            SelectEverythingVsSelectCertainColumns.SelectCertainCoumnsFast(adsDbContext);
        }
    }
}
