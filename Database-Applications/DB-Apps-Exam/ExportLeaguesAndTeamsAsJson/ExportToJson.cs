namespace ExportLeaguesAndTeamsAsJson
{
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using EF_Mapping;

    public class ExportToJson
    {
        public static void Main()
        {
            var context = new FootballEntities();
            string filePath = @"../../leagues-and-teams.json.json";

            var leaguesWithTeams = context.Leagues
                .Include(l => l.Teams)
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams
                            .OrderBy(t => t.TeamName)
                            .Select(t => t.TeamName)
                            .ToList()

                }).ToList();

            var leaguesWithTeamsSerialized = JsonConvert.SerializeObject(leaguesWithTeams, Formatting.Indented);
            File.WriteAllText(filePath, leaguesWithTeamsSerialized);
        }
    }
}
