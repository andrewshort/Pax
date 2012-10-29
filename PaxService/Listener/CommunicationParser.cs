using Common;
using PaxService.Packet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace PaxService.Listener
{
    public class CommunicationParser : ICommunicationParser
    {
        private IMessageBuilder _messageBuilder;
        private IMessageProcessor _messageProcessor;
        private IEncodingAdapter _encodingAdapter;
        private ILogger _logger;

        public CommunicationParser(IMessageBuilder messageBuilder, IMessageProcessor messageProcessor, IEncodingAdapter encodingAdapter, ILogger logger)
        {
            this._messageBuilder = messageBuilder;
            this._messageProcessor = messageProcessor;
            this._encodingAdapter = encodingAdapter;
            this._logger = logger;
        }

        public void HandleCommunication(TcpClient client)
        {
            var stream = new StreamWriter(client.GetStream());

            // send $AVREQ,?*CHKSUM
            var requestMessage = _messageBuilder.AvRequest();
            stream.Write(requestMessage);
            stream.Flush();

            var buffer = new byte[client.ReceiveBufferSize];
            client.GetStream().BeginRead(buffer, 0, client.ReceiveBufferSize, ReceiveMessage, new AsyncInfo(buffer, client));
        }

        private void ReceiveMessage(IAsyncResult result)
        {
            var asyncInfo = (AsyncInfo)result.AsyncState;

            var client = asyncInfo.Client;
            try
            {
                int bytesRead = client.GetStream().EndRead(result);

                if (bytesRead == 0)
                {
                    client.GetStream().Close();
                    return;
                }

                var message = _encodingAdapter.GetString(asyncInfo.ByteArray, 0, bytesRead);

                _messageProcessor.Process(message, client);

                client.GetStream().BeginRead(asyncInfo.ByteArray, 0, client.ReceiveBufferSize, ReceiveMessage, asyncInfo);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
        }
    }
}
