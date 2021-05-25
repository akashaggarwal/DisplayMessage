using MessageAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI
{
    public interface IMessageLogger
    {
        string name { get; }
        string WriteMessage();
    }
}
