using System;
using System.Collections.Generic;
using System.Text;
using BracketBuilder.Processor.Interfaces;
using BracketBuilder.Processor.Models;

namespace BracketBuilder.Processor
{
    public class CommandRunner
    {
        private ICommand _command;
        private IFileManager _data;
        private List<ParameterValue> _parameters;
        public CommandRunner(ICommand command, IFileManager data, List<ParameterValue> parameters)
        {
            _command = command;
            _data = data;
            _parameters = parameters;
        }

        public CommandResult Run()
        {
            return _command.Run(_data, _parameters);
        }
    }
}
