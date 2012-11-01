using Pax.Data.Interfaces;
using PaxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pax.Data
{
    public class DeviceRepository : IDeviceRepository
    {
        private PaxEntities context;

        public DeviceRepository()
        {
            context = new PaxEntities();
        }

        public IEnumerable<Device> GetDevices()
        {
            return context.Devices;            
        }

        public Device GetDeviceByUnitID(int unitId)
        {
            return context.Devices.FirstOrDefault(d => d.UnitID == unitId);
        }

        public Device GetDeviceByDeviceID(int deviceId)
        {
            return context.Devices.FirstOrDefault(d => d.DeviceID == deviceId);
        }

        public void UpdateDevice(int unitId, string firmwareVersion, string serialNumber, int memorySize)
        {
            
        }
    }
}
