﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using App.Configuration.Properties;
using Newtonsoft.Json;
using WeatherReportApp.Core;

namespace WeatherReportApp.Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly string BaseUrl = Settings.Default.WeatherStackBaseUrl;
        private readonly string ApiKey = Settings.Default.WeatherStackApiKey;
        private readonly HttpClient httpClient;

        public WeatherService()
        {
            httpClient = new HttpClient();
        }

        //We implememnt 
        public async Task<WeatherData> GetWeatherData(string cityName)
        {
            var response = await httpClient.GetStringAsync($"{BaseUrl}?access_key={ApiKey}&query={cityName}");

            var weatherData = JsonConvert.DeserializeObject<WeatherData>(response); //deserialize Json response from api

            return weatherData;
        }
    }
}
