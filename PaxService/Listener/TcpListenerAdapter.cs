using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace PaxService.Listener
{
    public class TcpListenerAdapter : ITcpListenerAdapter
    {
        private TcpListener _tcpListener;

        public TcpListenerAdapter(IConfigManager configManager)
        {
            _tcpListener = new TcpListener(IPAddress.Any, configManager.GetServerPort());
            _tcpListener.Start();
        }

        public IAsyncResult BeginAcceptTcpClient(AsyncCallback callback, object state)
        {
            return _tcpListener.BeginAcceptTcpClient(callback, state);
        }

        public System.Net.Sockets.TcpClient EndAcceptTcpClient(IAsyncResult result)
        {
            return _tcpListener.EndAcceptTcpClient(result);
        }
    }
}
