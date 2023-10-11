using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        public string Get(string key)
        {
            return Properties.Settings.Default[key]?.ToString();
        }
    }

}
