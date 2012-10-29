using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Listener
{
    public class AsyncInfo
    {
        public byte[] ByteArray { get; set; }
        public TcpClient Client { get; set; }

        public AsyncInfo(byte[] array, TcpClient client)
        {
            ByteArray = array;
            Client = client;
        }
    }
}
