namespace ImportLeaguesAndTeamsFromXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using EF_Mapping;

    public class ImportFromXml
    {
        public static void Main()
        {
            var context = new FootballEntities();
            var xmlDoc = XDocument.Load(@"../../leagues-and-teams.xml");
            var xPathQuery = "/leagues-and-teams/league";
            var leagueNodes = xmlDoc.XPathSelectElements(xPathQuery);
            int leaguesCounter = 0;

            foreach (var leagueNode in leagueNodes)
            {
                leaguesCounter++;
                Console.WriteLine("Processing league #{0} ...", leaguesCounter);
                League league = new League();
                // check if leagueName exists
                if (leagueNode.Element("league-name") != null)
                {
                    string leagueName = leagueNode.Element("league-name").Value;
                    // check if league exists in DB
                    league = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
                    if (league == null)
                    {
                        league = new League() { LeagueName = leagueName };
                        Console.WriteLine("Created league: {0}", leagueName);
                    }
                    else
                    {
                        Console.WriteLine("Existing league: {0}", leagueName);
                    }
                }

                // check if teams exists
                if (leagueNode.Element("teams") != null)
                {
                    var teamNodes = leagueNode.XPathSelectElements("teams/team");

                    if (teamNodes.Count() != 0)
                    {
                        foreach (var teamNode in teamNodes)
                        {
                            string teamName = teamNode.Attribute("name").Value;
                            string teamCountry = null;
                            var team = new Team();
                            if (teamNode.Attribute("country") != null)
                            {
                                teamCountry = teamNode.Attribute("country").Value;
                                team = context.Teams
                               .FirstOrDefault(t => t.TeamName == teamName && t.Country.CountryName == teamCountry);
                            }
                            else
                            {
                                team = context.Teams
                              .FirstOrDefault(t => t.TeamName == teamName);
                            }

                            if (team == null)
                            {
                                team = new Team() { TeamName = teamName };
                                var teamCountyExisting = context.Countries.FirstOrDefault(c => c.CountryName == teamCountry);
                                team.Country = teamCountyExisting;
                                league.Teams.Add(team);
                                Console.WriteLine("Created team: {0} ({1})", teamName, teamCountry);
                                Console.WriteLine("Added team to league: {0} to {1}", teamName, league.LeagueName);
                            }
                            else
                            {
                                Console.WriteLine("Existing team: {0} {1}", teamName, teamCountry);
                                if (!league.Teams.Contains(team))
                                {
                                    league.Teams.Add(team);
                                    Console.WriteLine("Added team to league: {0} to {1}", teamName, league.LeagueName);
                                }
                            }
                        }
                    }

                    if (leagueNode.Element("league-name") != null && leagueNode.Element("teams") != null)
                    {
                        context.Leagues.Add(league);
                        context.SaveChanges();
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
