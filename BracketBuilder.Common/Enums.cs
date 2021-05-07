using System;

namespace BracketBuilder.Common
{
    public static class Enums
    {
        public enum ConsoleCommands
        {
            SeedTeam = 1,
            AdvanceTeam = 2,
            IsBracketComplete = 3,
            FindChampion = 4,
            PathToVictory = 5
        }

        public enum CommandArgs
        {
            Team = 1,
            Seed = 2,
            Region = 3,
        }
    }
}
