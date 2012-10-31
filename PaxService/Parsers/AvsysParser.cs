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
    public class AvsysParser : IAvsysParser
    {
        private ICheckSum _checkSum;

        public AvsysParser(ICheckSum checkSum)
        {
            this._checkSum = checkSum;
        }

        public IAvsysObject Parse(string sentence)
        {
            // AVSYS,80003757,150,4035239305,160*4F
            if (!_checkSum.IsValid(sentence))
                return null;

            var avsys = ContainerManager.Resolve<IAvsysObject>();

            var parameters = sentence.Split('*')[0].Split(',');

            if (!parameters[0].Equals("AVSYS"))
            {
                return null;
            }

            avsys.UnitID = Convert.ToInt32(parameters[1]);
            avsys.FirmwareVersion = parameters[2];
            avsys.SerialNumber = parameters[3];
            avsys.MemorySize = Convert.ToInt32(parameters[4]);

            return avsys;
        }
    }
}
