namespace EF_Mapping
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ListAllTeamNames
    {
        public static void Main()
        {
            var context = new FootballEntities();
            var teamNames = context.Teams
                .Select(t => t.TeamName)
                .ToList();

            foreach (var teamName in teamNames)
            {
                Console.WriteLine(teamName);
            }
        }
    }
}
