using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BracketBuilder.Common;
using BracketBuilder.Processor;
using BracketBuilder.Processor.Commands;
using BracketBuilder.Processor.Interfaces;
using BracketBuilder.Processor.Models;

namespace BasketballBracketBuilder.Helpers
{
    public class ConsoleManager
    {
        public void AwaitCommand(bool displayHelp = false)
        {
            if (displayHelp)
            {
                showHelp();
            }

            if(parseCommand(Console.ReadLine(), out ICommand command, out List<ParameterValue> parameters))
            {
                var result = runCommand(command, parameters);

                if (!string.IsNullOrEmpty(result.Result))
                {
                    Console.WriteLine(result.Result);
                }
            }

            AwaitCommand();
        }

        private bool parseCommand(string command, out ICommand commandObject, out List<ParameterValue> parameters)
        {
            Enums.ConsoleCommands parsedCommand;
            commandObject = null;

            var split = command.Split(new string[] { "--" }, StringSplitOptions.RemoveEmptyEntries);
            var splitCommand = split.First().Trim();
            parameters = new List<ParameterValue>();

            for (int i = 1; i < split.Length; i++)
            {
                Enums.CommandArgs parsedParam;
                var paramSeperator = split[i].Split(':');
                
                if (Enum.TryParse(paramSeperator.First(), true, out parsedParam))
                {
                    parameters.Add(new ParameterValue() { Parameter = parsedParam, Value = paramSeperator[1].Trim() });
                }
            }

            if(Enum.TryParse(splitCommand, true, out parsedCommand))
            {
                switch (parsedCommand)
                {
                    case Enums.ConsoleCommands.SeedTeam:
                        commandObject = new SeedTeam();
                        break;
                    case Enums.ConsoleCommands.AdvanceTeam:
                        commandObject = new AdvanceTeam();
                        break;
                    case Enums.ConsoleCommands.IsBracketComplete:
                        commandObject = new IsBracketComplete();
                        break;
                    case Enums.ConsoleCommands.FindChampion:
                        commandObject = new FindChampion();
                        break;
                    case Enums.ConsoleCommands.PathToVictory:
                        commandObject = new PathToVictory();
                        break;
                }

                return true;
            }
            else
            {
                showHelp();
                return false;
            }
        }

        private CommandResult runCommand(ICommand command, List<ParameterValue> parameters)
        {
            return new CommandRunner(command, new FileManager(), parameters).Run();
        }

        private void showHelp()
        {
            Console.WriteLine("Please enter one of the following commands.");

            foreach (var command in Enum.GetValues(typeof(Enums.ConsoleCommands)))
            {
                Console.WriteLine($"{command.ToString()} or {(int)command}");
            }
        }
    }
}
