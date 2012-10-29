using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common
{
    public class ConfigManager : IConfigManager
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public int GetServerPort()
        {
            return Convert.ToInt32(Get("ServerPort"));
        }
    }
}
