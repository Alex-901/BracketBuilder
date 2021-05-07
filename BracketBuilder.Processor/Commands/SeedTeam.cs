using BracketBuilder.Processor.Interfaces;
using BracketBuilder.Processor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BracketBuilder.Processor.Commands
{
    public class SeedTeam : ICommand
    {
        public CommandResult Run(IFileManager fileManager, List<ParameterValue> parameters)
        {
            var data = fileManager.GetSeed();

            var team = parameters.Where(x => x.Parameter == Common.Enums.CommandArgs.Team).FirstOrDefault();
            var regionParam = parameters.Where(x => x.Parameter == Common.Enums.CommandArgs.Region).FirstOrDefault();
            var seed = parameters.Where(x => x.Parameter == Common.Enums.CommandArgs.Seed).FirstOrDefault();

            var newSeed = new RegionTeams();

            foreach (var region in data.RegionTeamDataSet)
            {
                var teamNames = new List<string>();
                var currentRegion = data.RegionTeamDataSet.Where(x => x.Name == region.Name).FirstOrDefault();

                for (int i = 0; i < currentRegion.TeamNames.Count(); i++)
                {
                    if (i == Convert.ToInt32(seed.Value) - 1 && currentRegion.Name.ToUpper() == regionParam.Value.ToUpper())
                    {
                        teamNames.Add(team.Value);
                    }
                    else 
                    {
                        if (currentRegion.TeamNames[i] == team.Value)
                            continue;

                        teamNames.Add(currentRegion.TeamNames[i]);
                    }
                }

                newSeed.RegionTeamDataSet.Add(new RegionTeam() { Name = currentRegion.Name, TeamNames = teamNames });
            }

            fileManager.SaveSeed(newSeed);

            return new CommandResult();
        }
    }
}
