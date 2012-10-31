using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Model.Interfaces
{
    public interface IAvrmcObject
    {
        string UnitId { get; set; }
        string UtcTime { get; set; }
        string Status { get; set; }
        string Latitude { get; set; }
        string NorthSouthInd { get; set; }
        string Longitude { get; set; }
        string EastWestInd { get; set; }
        string Speed { get; set; }
        string Course { get; set; }
        string UtcDate { get; set; }
        string EventCode { get; set; }
        string BatteryVoltage { get; set; }
        string CurrentMileage { get; set; }
        string GpsInd { get; set; }
        string AnalogPort1 { get; set; }
        string AnalogPort2 { get; set; }
        string CheckSum { get; set; }
        string Sentence { get; set; }
    }
}
