using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BracketBuilder.Processor.Models
{
    public class Advance
    {
        public Advance()
        {
            Advances = new List<string>();
        }
        public List<string> Advances { get; set; }

        [JsonIgnore]
        public bool IsBracketComplete
        {
            get
            {
                return Advances.GroupBy(x => x).Any(y => y.Count() == 6);
            }
        }

        [JsonIgnore]
        public string Champion
        {
            get
            {
                return IsBracketComplete ? Advances.GroupBy(x => x).Where(y => y.Count() == 6).FirstOrDefault().Key : string.Empty;
            }
        }
    }
}