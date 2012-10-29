using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common
{
    public class EncodingAdapter : IEncodingAdapter
    {
        private ASCIIEncoding _encoder;

        public EncodingAdapter()
        {
            this._encoder = new ASCIIEncoding();
        }

        public string GetString(byte[] byteArray, int byteIndex, int byteCount)
        {
            return _encoder.GetString(byteArray, byteIndex, byteCount);
        }
    }
}
