using System;
using WeatherReportApp.Core.Interfaces;
using WeatherReportApp.Core;
using WeatherReportApp.Infrastructure.Services;

namespace WeatherAnalysis
{
    static class Program
    {
        static async Task Main(string[] args) 
        {
            Console.WriteLine("Enter the name of the city for which you want to generate a weather report:");
            string? cityName = Console.ReadLine();
            if (string.IsNullOrEmpty(cityName))
            {
                Console.WriteLine("No city name provided. Exiting...");
                return;
            }

            // Create an instance of WeatherService and fetch weather data
            IWeatherService weatherService = new WeatherService();
            WeatherData weatherData = await weatherService.GetWeatherData(cityName);

            // Create an instance of PdfReportService and generate PDF report
            IPdfReportService pdfReportService = new PdfReportService();
            

            // Save the generated PDF
            string outputPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{cityName}_WeatherReport.pdf";
            var pdfDocument = pdfReportService.GenerateWeatherReport(weatherData, outputPath);
            pdfDocument.Save(outputPath);
            Console.WriteLine($"Weather report for {cityName} has been saved to: {outputPath}");

            Console.ReadLine(); // Just to pause the console
        }
    }


}
