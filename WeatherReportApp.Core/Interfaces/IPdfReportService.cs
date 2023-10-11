using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReportApp.Core.Interfaces
{
    public interface IPdfReportService
    {
        PdfDocument GenerateWeatherReport(WeatherData weatherData, string outputFilePath);
    }
}
