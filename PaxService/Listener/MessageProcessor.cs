using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Listener
{
    public class MessageProcessor : IMessageProcessor
    {
        private ICheckSum _checkSum;

        public MessageProcessor(ICheckSum checkSum)
        {
            this._checkSum = checkSum;
        }

        public void Process(string message, TcpClient client)
        {
            if (!string.IsNullOrEmpty(message))
            {
                var validSentences = message.Split('$').Where(x => _checkSum.IsValid(x)).Select(x => x.Trim());

                foreach (var sentence in validSentences)
                {
                    var sentenceType = sentence.Split(',')[0];

                    switch (sentenceType)
                    {
                        case "AVRMC":

                            break;
                        case "AVSYS":

                            break;

                        case "ECHK":

                            break;

                    }
                }
            }
        }
    }
}
