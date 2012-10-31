using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Handlers.Interfaces
{
    public interface IAvsysHandler
    {
        void Handle(string sentence, TcpClient client);
    }
}
