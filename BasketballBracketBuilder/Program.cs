using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballBracketBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Helpers.ConsoleManager().AwaitCommand(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unhandled exception has occured" + Environment.NewLine + ex.Message);
            }
        }
    }
}
