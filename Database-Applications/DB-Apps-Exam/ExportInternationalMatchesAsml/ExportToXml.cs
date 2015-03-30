namespace ExportInternationalMatchesAsml
{
    using System;
    using System.Data.Entity;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    using EF_Mapping;

    public class ExportToXml
    {
        public static void Main()
        {
            string filePath = @"../../international-matches.xml";
            var context = new FootballEntities();

            var mathes = context.InternationalMatches
                .Include(m => m.League)
                .OrderBy(m => m.MatchDate)
                .ThenBy(m => m.Country1.CountryName)
                .ThenBy(m => m.Country.CountryName)
                .Select(m => new
                {
                    MatchDateTime = m.MatchDate,
                    HomeCountryName = m.Country1.CountryName,
                    AwayCountryName = m.Country.CountryName,
                    HomeCounryCode = m.HomeCountryCode,
                    AwayCountryCode = m.AwayCountryCode,
                    HomeGoals = m.HomeGoals,
                    AwayGoals = m.AwayGoals,
                    League = m.League.LeagueName
                }).ToList();

            XDocument doc = new XDocument();
            var xmlRoot = new XElement("matches");
            foreach (var match in mathes)
            {
                var matchXml = new XElement("match");// TODO DATE

                // add attribute for date if exists
                if (match.MatchDateTime != null)
                {
                   // string date = match.MatchDateTime.ToString("MM-dd-yy");
                    matchXml.Add(new XAttribute("date-time", match.MatchDateTime));
                }

                var homeCountryXml = new XElement("home-country", match.HomeCountryName);
                homeCountryXml.Add(new XAttribute("code", match.HomeCounryCode));
                matchXml.Add(homeCountryXml);

                var awayCountryXml = new XElement("away-country", match.AwayCountryName);
                awayCountryXml.Add(new XAttribute("code", match.AwayCountryCode));
                matchXml.Add(awayCountryXml);
                xmlRoot.Add(matchXml);

                // ad xml element for scor if exists
                if (match.HomeGoals != null && match.AwayGoals != null)
                {
                    var scoreXml = new XElement("score", match.HomeGoals + "-" + match.AwayGoals);
                    matchXml.Add(scoreXml);
                }

                // add xml element for league if exists
                if (match.League != null)
                {
                    var leagueXml = new XElement("league", match.League);
                    matchXml.Add(leagueXml);
                }
            }

            doc.Add(xmlRoot);
            doc.Save(filePath);
        }
    }
}
