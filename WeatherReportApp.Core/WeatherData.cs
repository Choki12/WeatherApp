using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReportApp.Core
{
    /* The weatherstack api documentation specifies return objects for the described weather data objects*/
    
    public class WeatherData
    {
        public Request Request { get; set; }
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Dictionary<string, HistoricalData> Historical { get; set; }
    }

    public class Request
    {
        public string Type { get; set; }
        public string Query { get; set; }
        public string Language { get; set; }
        public string Unit { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string TimezoneId { get; set; }
        public string LocalTime { get; set; }
        public long LocalTimeEpoch { get; set; }
        public string UtcOffset { get; set; }
    }

    public class Current
    {
        public string ObservationTime { get; set; }
        public int Temperature { get; set; }
        public int WeatherCode { get; set; }
        public List<string> WeatherIcons { get; set; }
        public List<string> WeatherDescriptions { get; set; }
        public int Windspeed { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

    }

    public class HistoricalData
    {
        public string Date { get; set; }
        public long DateEpoch { get; set; }
        public int Mintemp { get; set; }
    
    }
}
