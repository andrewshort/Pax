using Common.Interfaces;
using Pax.Data.Interfaces;
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
        private IDeviceRepository _deviceRepository;
        private ICommandService _commandService;

        public AvsysHandler(IAvsysParser parser, ILogger logger, IDeviceRepository deviceRepository, ICommandService commandService)
        {
            this._parser = parser;
            this._logger = logger;
            this._deviceRepository = deviceRepository;
            this._commandService = commandService;
        }

        public void Handle(string sentence, TcpClient client)
        {
            IAvsysObject avsys = _parser.Parse(sentence);
            if (avsys == null)
            {
                return;
            }

            _deviceRepository.UpdateDevice(avsys.UnitID, avsys.FirmwareVersion, avsys.SerialNumber, avsys.MemorySize);
            
            _commandService.RegisterClient(avsys.UnitID, client);

            _logger.LogMessage(avsys.Sentence);
        }
    }
}
