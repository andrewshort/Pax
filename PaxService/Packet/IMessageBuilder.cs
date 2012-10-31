using PaxService.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Packet
{
    public interface IMessageBuilder
    {
        string AvRequest();
        string Echk(string sentence);
        string Ack(IAvrmcObject avrmc);
        string AvcfgAck(IAvrmcObject avrmc, char code);
    }
}
