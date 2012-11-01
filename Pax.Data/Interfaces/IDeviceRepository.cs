using PaxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pax.Data.Interfaces
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> GetDevices();
        Device GetDeviceByUnitID(int unitId);
        Device GetDeviceByDeviceID(int deviceId);

        void UpdateDevice(int unitId, string firmwareVersion, string serialNumber, int memorySize);
    }
}
