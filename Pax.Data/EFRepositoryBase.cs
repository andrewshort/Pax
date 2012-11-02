using PaxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pax.Data
{
    public abstract class EFRepositoryBase
    {
        protected PaxEntities Context
        {
            get;
            set;
        }

        public EFRepositoryBase()
        {
            Context = new PaxEntities();
        }
    }
}
