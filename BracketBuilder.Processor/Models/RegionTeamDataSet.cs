using System;
using System.Collections.Generic;
using System.Text;

namespace BracketBuilder.Processor.Models
{
    public class RegionTeams
    {
        public RegionTeams()
        {
            RegionTeamDataSet = new List<RegionTeam>();
        }
        public List<RegionTeam> RegionTeamDataSet { get; set; }
    }

    public class RegionTeam
    {
        public string Name { get; set; }

        public List<string> TeamNames { get; set; }
    }
}