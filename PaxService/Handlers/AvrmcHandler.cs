using Common.Interfaces;
using PaxService.Handlers.Interfaces;
using PaxService.Model.Enum;
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
    public class AvrmcHandler : IAvrmcHandler
    {
        private IAvrmcParser _parser;
        private ILogger _logger;
        private IEventTypeParser _eventTypeParser;
        private IMessageBuilder _messageBuilder;
        private IMessageWriter _messageWriter;

        public AvrmcHandler(IAvrmcParser parser, ILogger logger, IEventTypeParser eventTypeParser, 
            IMessageBuilder messageBuilder, IMessageWriter messageWriter)
        {
            this._parser = parser;
            this._logger = logger;
            this._eventTypeParser = eventTypeParser;
            this._messageBuilder = messageBuilder;
            this._messageWriter = messageWriter;
        }

        public void Handle(string sentence, TcpClient client)
        {
            IAvrmcObject avrmc = _parser.Parse(sentence);

            // TODO: Process track
            _logger.LogMessage(avrmc.Sentence);

            SendAck(avrmc, client);
        }

        private void SendAck(IAvrmcObject avrmc, TcpClient client)
        {
            EventType eventType = _eventTypeParser.GetEventType(avrmc);

            switch (eventType)
            {
                case (EventType.SOS):
                case (EventType.SOSV3):
                    _messageWriter.WriteMessage(_messageBuilder.AvcfgAck(avrmc, 'd'), client);
                    break;
                case (EventType.TamperDetection):
                    _messageWriter.WriteMessage(_messageBuilder.AvcfgAck(avrmc, 't'), client);
                    break;
                case (EventType.GeofenceEnter):
                case (EventType.GeofenceExit):
                    _messageWriter.WriteMessage(_messageBuilder.AvcfgAck(avrmc, 'x'), client);
                    break;
                case (EventType.AccidentShock):
                    _messageWriter.WriteMessage(_messageBuilder.Ack(avrmc), client);
                    break;
                default:
                    _messageWriter.WriteMessage(_messageBuilder.Ack(avrmc), client);
                    break;
            }
        }        
    }
}
