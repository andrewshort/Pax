using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common
{
    public class CheckSum : ICheckSum
    {
        public string Calculate(string message)
        {
            var temp = message;
            if (temp.StartsWith("$"))
                temp = temp.Substring(1);

            if (temp.Contains("*"))
                temp = temp.Split('*')[0];

            var trimmedMessage = message.TrimStart('$').Split('*')[0];

            int CheckSum = 0;
            if (trimmedMessage.Length > 0)
                CheckSum = Convert.ToByte(trimmedMessage[0]);

            for (int i = 1; i < trimmedMessage.Length; i++)
            {
                CheckSum ^= Convert.ToByte(trimmedMessage[i]);
            }

            return CheckSum.ToString("X2");
        }



        public bool IsValid(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
                return false;

            if (!sentence.Contains("*"))
                return false;

            return Calculate(sentence).Equals(sentence.Split('*')[1].Trim());
        }
    }
}
