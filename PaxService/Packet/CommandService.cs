using Common.Interfaces;
using Pax.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PaxService.Packet
{
    public class CommandService : ICommandService
    {
        private Timer commandTimer;
        private ILogger _logger;
        private ICommandRepository _commandRepository;

        private Dictionary<int, TcpClient> Clients;
        private IMessageWriter _messageWriter;

        public CommandService(ILogger logger, ICommandRepository commandRepository, IMessageWriter messageWriter)
        {
            this._logger = logger;
            this._commandRepository = commandRepository;
            this._messageWriter = messageWriter;

            Clients = new Dictionary<int, TcpClient>();
        }

        void commandTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                commandTimer.Stop();
                OnCommandTimer();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                commandTimer.Start();
            }
        }

        private void OnCommandTimer()
        {
            var commands = _commandRepository.GetCommands();

            foreach (var command in commands)
            {
                var client = Clients
                    .Where(c => c.Key == command.Device.UnitID)
                    .Select(c => c.Value)
                    .FirstOrDefault();

                if (client == null) return;

                _messageWriter.WriteMessage(command.CommandText, client);
            }
        }

        public void RegisterClient(int unitId, TcpClient client)
        {
            Clients[unitId] = client;
        }


        public void Start()
        {
            commandTimer = new Timer();
            commandTimer.Interval = 10 * 1000;
            commandTimer.Elapsed += commandTimer_Elapsed;
            commandTimer.Start();
        }

        public void Stop()
        {
            commandTimer.Stop();
            commandTimer.Elapsed -= commandTimer_Elapsed;
            commandTimer.Dispose();
        }
    }
}
