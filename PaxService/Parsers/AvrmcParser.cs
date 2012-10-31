using Common;
using Common.Interfaces;
using PaxService.Model.Interfaces;
using PaxService.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Parsers
{
    public class AvrmcParser : IAvrmcParser
    {
        private ICheckSum _checkSum;
        public AvrmcParser(ICheckSum checkSum)
        {
            this._checkSum = checkSum;
        }

        public IAvrmcObject Parse(string sentence)
        {
            //AVRMC,90006400,192742,v,0000.0000,N,00000.0000,E,0.00,0.00,301211,0,4026,0,1,0,0*37
            //"AVRMC,90006400,165039,A,4000.4663,N,08556.4742,W,0.10,150.43,301211,0,4033,0  ,1,0,0*1F"
            // AVRMC,12020000,155703,V,         ,N,          ,E,0.00,      ,200212,0,4063,111,1*3E

            if (!_checkSum.IsValid(sentence))
                return null;

            var avrmc = ContainerManager.Resolve<IAvrmcObject>();

            var parameters = sentence.Split('*')[0].Split(',');
            var csum = sentence.Split('*')[1];

            if (!parameters[0].Equals("AVRMC"))
            {
                return null;
            }

            avrmc.UnitId = parameters[1];
            avrmc.UtcTime = parameters[2];
            avrmc.Status = parameters[3];
            avrmc.Latitude = parameters[4];
            avrmc.NorthSouthInd = parameters[5];
            avrmc.Longitude = parameters[6];
            avrmc.EastWestInd = parameters[7];
            avrmc.Speed = parameters[8];
            avrmc.Course = parameters[9];
            avrmc.UtcDate = parameters[10];
            avrmc.EventCode = parameters[11];
            avrmc.BatteryVoltage = parameters[12];
            avrmc.CurrentMileage = parameters[13];
            avrmc.GpsInd = parameters[14];
            avrmc.AnalogPort1 = (parameters.Count() >= 17) ? parameters[15] : string.Empty;
            avrmc.AnalogPort2 = (parameters.Count() >= 17) ? parameters[16] : string.Empty;
            avrmc.CheckSum = csum;

            avrmc.Sentence = sentence;

            return avrmc;
        }
    }
}
