using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace PaxService.Packet
{
    public class MessageBuilder : IMessageBuilder
    {
        private const string AVREQ = "$AVREQ,?";
        private ICheckSum _checkSum;

        public MessageBuilder(ICheckSum checkSum)
        {
            this._checkSum = checkSum;
        }

        public string AvRequest()
        {
            return string.Format("{0}*{1}{2}", AVREQ, _checkSum.Calculate(AVREQ), Environment.NewLine);
        }
    }
}
