using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PaxService.Listener
{
    public class ListenerService : IListenerService
    {
        private Timer timer;
        public void Start()
        {
            timer = new Timer();
            timer.Interval = 2000;
            timer.Elapsed += x_Elapsed;
        }

        void x_Elapsed(object sender, ElapsedEventArgs e)
        {
            var y = 1;
        }

        public void Stop()
        {
            
        }
    }
}
