using Common.Interfaces;
using PaxService.Handlers.Interfaces;
using PaxService.Model.Interfaces;
using PaxService.Packet;
using PaxService.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Handlers
{
    public class AvsysHandler : IAvsysHandler
    {
        private IAvsysParser _parser;
        private ILogger _logger;

        public AvsysHandler(IAvsysParser parser, ILogger logger)
        {
            this._parser = parser;
            this._logger = logger;
        }

        public void Handle(string sentence, TcpClient client)
        {
            IAvsysObject avsys = _parser.Parse(sentence);
            if (avsys == null)
            {
                return;
            }

            // TODO: INSERT INTO DB, update device info, etc
            _logger.LogMessage(avsys.Sentence);
        }
    }
}
