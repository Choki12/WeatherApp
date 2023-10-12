using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using WeatherReportApp.Core;
using WeatherReportApp.Infrastructure.Services;

namespace WeatherAnalysisApp.Tests
{
    public class WeatherServiceTests
    {
        private readonly WeatherService _weatherService;
        private readonly Mock<HttpMessageHandler> _mockHandler;

        public WeatherServiceTests()
        {
            _mockHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_mockHandler.Object);
            _weatherService = new WeatherService(httpClient);
        }
        [Fact]
        public async Task GetWeatherData_ReturnsExpectedWeatherData()
        {
            // Arrange
            var cityName = "Paris";
            var expectedWeatherData = new WeatherData
            {
                Current = new Current 
                {
                    Temperature = 20,
                    Windspeed = 10,
                    Pressure = 32,
                    Humidity = 15,
                    
                },
        
            };

            var expectedJsonResponse = JsonConvert.SerializeObject(expectedWeatherData);
            var expectedResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(expectedJsonResponse),
            };

            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(expectedResponseMessage);

            // Act
            var result = await _weatherService.GetWeatherData(cityName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedWeatherData.Current.Temperature, result.Current.Temperature);

        }
    }
}
