using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxService.Model.Attributes
{
    public class StringValue : DescriptionAttribute
    {
        public StringValue(string value)
        {
            this.DescriptionValue = value;
        }
    }
}
