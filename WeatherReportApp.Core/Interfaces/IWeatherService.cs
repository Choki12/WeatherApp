using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReportApp.Core
{
    public interface IWeatherService
    {
        WeatherData GetWeatherData(string cityName);
    }
}
