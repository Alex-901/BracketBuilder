using BracketBuilder.Processor.Interfaces;
using BracketBuilder.Processor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BracketBuilder.Processor.Commands
{
    public class IsBracketComplete : ICommand
    {
        public CommandResult Run(IFileManager seedData, List<ParameterValue> parameters)
        {
            return new CommandResult() { Result = seedData.GetAdvances().IsBracketComplete ? "Yes" : "No" };
        }
    }
}
