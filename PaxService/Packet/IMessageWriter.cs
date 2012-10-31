using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Packet
{
    public interface IMessageWriter
    {
        void WriteMessage(string sentence, TcpClient client);
    }
}
