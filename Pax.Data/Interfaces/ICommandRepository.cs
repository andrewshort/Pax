using PaxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pax.Data.Interfaces
{
    public interface ICommandRepository
    {
        IEnumerable<Command> GetCommands();
    }
}
