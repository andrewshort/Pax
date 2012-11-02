using Pax.Data.Interfaces;
using PaxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pax.Data
{
    public class CommandRepository : EFRepositoryBase, ICommandRepository
    {
        public CommandRepository()
            : base()
        {

        }

        public IEnumerable<Command> GetCommands()
        {
            return Context.Commands;
        }
    }
}
