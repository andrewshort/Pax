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
                var validSentences = message.Split('$').Where(x => IsValid(x)).Select(x => x.Trim());

                //Process(validSentences, client);
            }
        }

        public bool IsValid(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
                return false;

            if (!sentence.Contains("*"))
                return false;

            return _checkSum.Calculate(sentence).Equals(sentence.Split('*')[1].Trim());
        }
    }
}
