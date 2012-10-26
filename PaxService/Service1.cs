using PaxService.Listener;
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

        public Service1(IListenerService listenerService)
        {
            _listenerService = listenerService;

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Run();
        }

        public void Run()
        {
            _listenerService.Start();
        }

        protected override void OnStop()
        {
            _listenerService.Stop();
        }
    }
}
