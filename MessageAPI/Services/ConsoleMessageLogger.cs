using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI.Services
{
    public class ConsoleMessageLogger : IMessageLogger
    {
        public string name { get; }

        public ConsoleMessageLogger()
        {
            this.name = "Console";
        }
        public string WriteMessage()
        {
            Console.WriteLine("Hello World");
            return "I wrote to console";
        }
    }
}
