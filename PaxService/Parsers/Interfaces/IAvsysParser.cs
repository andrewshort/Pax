using PaxService.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Parsers.Interfaces
{
    public interface IAvsysParser
    {
        IAvsysObject Parse(string sentence);
    }
}
