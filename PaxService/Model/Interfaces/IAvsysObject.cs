using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Model.Interfaces
{
    public interface IAvsysObject
    {
        int UnitID { get; set; }
        string FirmwareVersion { get; set; }
        string SerialNumber { get; set; }
        int MemorySize { get; set; }
    }
}
