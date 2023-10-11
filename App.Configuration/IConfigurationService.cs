using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Configuration
{
    public interface IConfigurationService
    {
        string Get(string key);
    }

}
