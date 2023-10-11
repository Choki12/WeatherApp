using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherReportApp.Core;
using WeatherReportApp.Core.Interfaces;


namespace WeatherReportApp.Infrastructure.Services
{
    public class PdfReportService : IPdfReportService
    {
        public PdfDocument GenerateWeatherReport(WeatherData weatherData, string outputFilePath)
        {
            try
            {
                // Create a new PDF document
                PdfDocument document = new PdfDocument();
                document.Info.Title = $"Weather Report for {weatherData.Location.Name}";

                // Create an empty page
                PdfPage page = document.AddPage();

                // Create graphics object
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Create font
                XFont titleFont = new XFont("Verdana", 20, XFontStyle.Bold);
                XFont font = new XFont("Verdana", 16, XFontStyle.Regular);

                // Title
                gfx.DrawString($"Weather Report for {weatherData.Location.Name}", titleFont, XBrushes.Black, new XRect(0, 20, page.Width, page.Height), XStringFormats.TopCenter);

                // Essential weather data
                gfx.DrawString($"Country: {weatherData.Location.Country}", font, XBrushes.Black, new XRect(0, 60, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString($"Region: {weatherData.Location.Region}", font, XBrushes.Black, new XRect(0, 90, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString($"Temperature: {weatherData.Current.Temperature}°C", font, XBrushes.Black, new XRect(0, 120, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString($"Weather: {string.Join(", ", weatherData.Current.WeatherDescriptions)}", font, XBrushes.Black, new XRect(0, 150, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString($"Wind Speed: {weatherData.Current.Windspeed} km/h", font, XBrushes.Black, new XRect(0, 180, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString($"Pressure: {weatherData.Current.Pressure} MB", font, XBrushes.Black, new XRect(0, 210, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString($"Humidity: {weatherData.Current.Humidity}%", font, XBrushes.Black, new XRect(0, 240, page.Width, page.Height), XStringFormats.TopLeft);

                return document;
            }
            catch (Exception ex)
            {
                // Error handling
                throw new InvalidOperationException($"Failed to generate the weather report for {weatherData.Location.Name}", ex);
            }
        }
    }
}
