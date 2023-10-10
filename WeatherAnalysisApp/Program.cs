using System;

namespace WeatherAnalysis
{
    static class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Please enter the city name:");

            var cityName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cityName))
            {
                Console.WriteLine("City name cannot be empty.");
            }

            //business logic

            Console.WriteLine("Weather report generated successfully");
        }
    }


}
