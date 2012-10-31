using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Packet
{
    public class MessageWriter : IMessageWriter
    {
        private ICheckSum _checkSum;
        private ILogger _logger;
        public MessageWriter(ICheckSum checkSum, ILogger logger)
        {
            this._checkSum = checkSum;
            this._logger = logger;
        }

        public void WriteMessage(string sentence, TcpClient client)
        {
            var stream = new StreamWriter(client.GetStream());

            var message = string.Format("${0}*{1}{2}", sentence, _checkSum.Calculate(sentence), Environment.NewLine);
            stream.Write(message);
            _logger.LogMessage("OUTBOUND: " + message);
            stream.Flush();
        }
    }
}
