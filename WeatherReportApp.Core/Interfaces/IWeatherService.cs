using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReportApp.Core
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherData(string cityName);
    }
}
