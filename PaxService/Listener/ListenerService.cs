using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PaxService.Listener
{
    public class ListenerService : IListenerService
    {
        private bool isRunning;
        private AutoResetEvent connectionWaitHandle = new AutoResetEvent(false);
        private ITcpListenerAdapter _listenerAdapter;
        private ICommunicationParser _communicationParser;

        public ListenerService(ITcpListenerAdapter listenerAdapter, ICommunicationParser communicationParser)
        {
            this._listenerAdapter = listenerAdapter;
            this._communicationParser = communicationParser;
        }

        public void Start()
        {
            var listenerThread = new Thread(Listen);
            listenerThread.Start();
        }

        private void Listen()
        {
            isRunning = true;

            while (isRunning)
            {
                var result = _listenerAdapter.BeginAcceptTcpClient(HandleConnection, _listenerAdapter);
                connectionWaitHandle.WaitOne();
            }
        }

        private void HandleConnection(IAsyncResult result)
        {
            ITcpListenerAdapter listener = (ITcpListenerAdapter)result.AsyncState;
            var client = listener.EndAcceptTcpClient(result);
            connectionWaitHandle.Set();

            _communicationParser.HandleCommunication(client);
        }

        public void Stop()
        {
            isRunning = false;
            connectionWaitHandle.Set();
        }
    }
}
