using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Listener
{
    public interface IMessageProcessor
    {
        void Process(string message, TcpClient client);
        bool IsValid(string sentence);
    }
}
