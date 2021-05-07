using BracketBuilder.Processor.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BracketBuilder.Processor.Models
{
    public class FileManager : IFileManager
    {
        public Advance GetAdvances()
        {
            string path = @"C:\Users\alex_\source\repos\BasketballBracketBuilder\BracketBuilder.Processor\Files\advances.json";
            var file = File.ReadAllText(path);
            Advance seedData = (Advance)JsonConvert.DeserializeObject(file, typeof(Advance));
            return seedData;
        }

        public void SaveAdvances(Advance advances)
        {
            string path = @"C:\Users\alex_\source\repos\BasketballBracketBuilder\BracketBuilder.Processor\Files\advances.json";

            File.WriteAllText(path, JsonConvert.SerializeObject(advances));
        }

        public virtual RegionTeams GetSeed()
        {
            string path = @"C:\Users\alex_\source\repos\BasketballBracketBuilder\BracketBuilder.Processor\Files\seed.json";
            var file = File.ReadAllText(path);
            RegionTeams seedData = (RegionTeams)JsonConvert.DeserializeObject(file, typeof(RegionTeams));
            return seedData;
        }

        public virtual void SaveSeed(RegionTeams seed)
        {
            string path = @"C:\Users\alex_\source\repos\BasketballBracketBuilder\BracketBuilder.Processor\Files\seed.json";

            File.WriteAllText(path, JsonConvert.SerializeObject(seed));
        }
    }
}
