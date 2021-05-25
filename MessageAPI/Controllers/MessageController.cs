using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageLogger _messageLogger;
        private readonly IConfiguration _config;
        public MessageController(IConfiguration config,IEnumerable<IMessageLogger> messageLoggers)
        {
            _config = config;
            _messageLogger = messageLoggers.SingleOrDefault(m=>m.name.Equals(_config["MessageLoggerType"]));
        }

        [HttpGet]
        public string  Get()
        {
            return _messageLogger.WriteMessage();
        }
    }
}
