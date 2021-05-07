using BracketBuilder.Processor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BracketBuilder.Processor.Interfaces
{
    public interface ICommand
    {
        CommandResult Run(IFileManager seedData, List<ParameterValue> parameters);
    }
}
