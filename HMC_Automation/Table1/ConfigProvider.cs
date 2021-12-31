using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMC_Automation
{
    public static class ConfigProvider
    {
        public static string GetConfigValue(string key)
        {
            return Convert.ToString(ConfigurationManager.AppSettings[key]);
        }

    }
}
