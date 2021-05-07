using BracketBuilder.Processor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BracketBuilder.Processor.Interfaces
{
    public interface IFileManager
    {
        RegionTeams GetSeed();

        void SaveSeed(RegionTeams seed);

        Advance GetAdvances();

        void SaveAdvances(Advance seed);
    };
}
