using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ILogger
    {
        void LogException(Exception ex);
        void LogMessage(string message);
    }
}
