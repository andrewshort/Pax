using PaxService.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Model
{
    public class AvrmcObject : IAvrmcObject
    {
        public string UnitId
        {
            get;
            set;
        }

        public string UtcTime
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string Latitude
        {
            get;
            set;
        }

        public string NorthSouthInd
        {
            get;
            set;
        }

        public string Longitude
        {
            get;
            set;
        }

        public string EastWestInd
        {
            get;
            set;
        }

        public string Speed
        {
            get;
            set;
        }

        public string Course
        {
            get;
            set;
        }

        public string UtcDate
        {
            get;
            set;
        }

        public string EventCode
        {
            get;
            set;
        }

        public string BatteryVoltage
        {
            get;
            set;
        }

        public string CurrentMileage
        {
            get;
            set;
        }

        public string GpsInd
        {
            get;
            set;
        }

        public string AnalogPort1
        {
            get;
            set;
        }

        public string AnalogPort2
        {
            get;
            set;
        }

        public string CheckSum
        {
            get;
            set;
        }

        public string Sentence
        {
            get;
            set;
        }
    }
}
