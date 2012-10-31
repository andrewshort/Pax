using PaxService.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Handlers
{
    public class AvsysHandler : IAvsysHandler
    {
        public void Handle(string sentence, TcpClient client)
        {
            throw new NotImplementedException();
        }
    }
}
