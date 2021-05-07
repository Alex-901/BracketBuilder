using BracketBuilder.Processor.Interfaces;
using BracketBuilder.Processor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BracketBuilder.Processor.Commands
{
    public class AdvanceTeam : ICommand
    {
        public CommandResult Run(IFileManager fileManager, List<ParameterValue> parameters)
        {
            var team = parameters.Where(x => x.Parameter == Common.Enums.CommandArgs.Team).FirstOrDefault();
            var data = fileManager.GetAdvances();

            data.Advances.Add(team.Value);

            fileManager.SaveAdvances(data);

            return new CommandResult();
        }
    }
}
