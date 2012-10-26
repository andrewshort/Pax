using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Listener
{
    public interface IListenerService
    {
        void Start();
        void Stop();
    }
}
