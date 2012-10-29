using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Listener
{
    public interface ITcpListenerAdapter
    {
        IAsyncResult BeginAcceptTcpClient(AsyncCallback callback, object state);
        TcpClient EndAcceptTcpClient(IAsyncResult result);
    }
}
