using PaxService.Listener;
using PaxService.Packet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PaxService
{
    public partial class Service1 : ServiceBase
    {
        private IListenerService _listenerService;
        private ICommandService _commandService;

        public Service1(IListenerService listenerService, ICommandService commandService)
        {
            _listenerService = listenerService;
            _commandService = commandService;

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Run();
        }

        public void Run()
        {
            _listenerService.Start();
            _commandService.Start();
        }

        protected override void OnStop()
        {
            _listenerService.Stop();
            _commandService.Stop();
        }
    }
}
