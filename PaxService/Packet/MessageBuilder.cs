using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using PaxService.Model.Interfaces;

namespace PaxService.Packet
{
    public class MessageBuilder : IMessageBuilder
    {
        private ICheckSum _checkSum;

        public MessageBuilder(ICheckSum checkSum)
        {
            this._checkSum = checkSum;
        }

        public string AvRequest()
        {
            return "$AVREQ,?";
        }

        public string Echk(string sentence)
        {
            return string.Format("{0}{1}{2}", "$", sentence, Environment.NewLine);
        }

        public string Ack(IAvrmcObject avrmc)
        {
            return string.Format("EAVACK,{0},{1}", avrmc.EventCode, avrmc.CheckSum);
        }

        public string AvcfgAck(IAvrmcObject avrmc, char code)
        {
            return string.Format("AVCFG,{0},{1}", "00000000");
        }
    }
}
