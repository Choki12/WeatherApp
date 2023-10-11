using System;
using System.IO;
using WeatherReportApp.Core.Interfaces;
using WeatherReportApp.Core;
using WeatherReportApp.Infrastructure.Services;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            /*Specific character encodings are not available in .NET Core, this registers non-standard encodings for certain styles and fonts for PDFSharp library when used*/
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            try
            {
                Console.WriteLine("Enter the name of the city for which you want to generate a weather report:");
                string? cityName = Console.ReadLine();

                if (string.IsNullOrEmpty(cityName))
                {
                    Console.WriteLine("No city name provided. Exiting...");
                    return;
                }

            
                IWeatherService weatherService = new WeatherService();
                WeatherData weatherData = await weatherService.GetWeatherData(cityName);

                if (weatherData == null)
                {
                    Console.WriteLine("Failed to fetch weather data. Exiting...");
                    return;
                }

                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var projectRootDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent; //traverse up to find project root 

                if (projectRootDirectory == null)
                {
                    Console.WriteLine("Error determining project root directory. Exiting..."); //terminate exexution if it cant be found
                    return;
                }

                string reportsDirectory = Path.Combine(projectRootDirectory.FullName, "Reports");
                if (!Directory.Exists(reportsDirectory))
                {
                    Directory.CreateDirectory(reportsDirectory);
                }

              
                IPdfReportService pdfReportService = new PdfReportService();

                // Save the generated PDF
                string outputPath = Path.Combine(reportsDirectory, $"{cityName}_WeatherReport.pdf");
                var pdfDocument = pdfReportService.GenerateWeatherReport(weatherData, outputPath);
                pdfDocument.Save(outputPath);
                Console.WriteLine($"Weather report for {cityName} has been saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine(); 
        }
    }
}
