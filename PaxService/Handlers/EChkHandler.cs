using Common.Interfaces;
using PaxService.Handlers.Interfaces;
using PaxService.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Handlers
{
    public class EChkHandler : IEchkHandler
    {
        private IMessageWriter _messageWriter;
        private IMessageBuilder _messageBuilder;
        private ILogger _logger;

        public EChkHandler(IMessageWriter messageWriter, IMessageBuilder messageBuilder, ILogger logger)
        {
            this._messageWriter = messageWriter;
            this._messageBuilder = messageBuilder;
            this._logger = logger;
        }

        public void Handle(string sentence, TcpClient client)
        {
            _logger.LogMessage(sentence);
            _messageWriter.WriteMessage(_messageBuilder.Echk(sentence), client);
        }
    }
}
