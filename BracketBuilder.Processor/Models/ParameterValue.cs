using System;
using System.Collections.Generic;
using System.Text;
using BracketBuilder.Common;


namespace BracketBuilder.Processor.Models
{
    public class ParameterValue
    {
        public Enums.CommandArgs Parameter { get; set; }
        public string Value { get; set; }
    }
}
