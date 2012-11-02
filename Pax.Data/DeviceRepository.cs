using Pax.Data.Interfaces;
using PaxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pax.Data
{
    public class DeviceRepository : EFRepositoryBase, IDeviceRepository
    {
        public DeviceRepository()
            : base()
        {

        }

        public IEnumerable<Device> GetDevices()
        {
            return Context.Devices;            
        }

        public Device GetDeviceByUnitID(int unitId)
        {
            return Context.Devices.FirstOrDefault(d => d.UnitID == unitId);
        }

        public Device GetDeviceByDeviceID(int deviceId)
        {
            return Context.Devices.FirstOrDefault(d => d.DeviceID == deviceId);
        }

        public void UpdateDevice(int unitId, string firmwareVersion, string serialNumber, int memorySize)
        {
            
        }
    }
}
