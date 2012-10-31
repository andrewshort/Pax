using PaxService.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Model
{
    public class AvsysObject : IAvsysObject
    {
        public int UnitID
        {
            get;
            set;
        }

        public string FirmwareVersion
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }

        public int MemorySize
        {
            get;
            set;
        }
    }
}
