using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI.Services
{
    public class DBMessageLogger : IMessageLogger
    {

        public string name { get; }

        public DBMessageLogger()
        {
            this.name = "DB";
        }
        public string WriteMessage()
        {
            Console.WriteLine("Hello World to DB");
            return "I wrote to DB";
        }
    }
}
