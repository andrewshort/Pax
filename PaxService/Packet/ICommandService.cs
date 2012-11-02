using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Packet
{
    public interface ICommandService
    {
        void RegisterClient(int unitId, TcpClient client);
        void Start();
        void Stop();
    }
}
