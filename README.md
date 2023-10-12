# WeatherApp🌦

"I'm sorry Ms Jackson. You can plan a pretty picnic. But you can't predict the weather. I'm sorry Ms. Jackson (oh), I am for real.."

This is a .NET Core Console App that fetches current weather data from the Weatherstack API. Simply input a city name, and the app provides you with current weather conditions, saving the data locally to a PDF file prefixed with the city name.

## Prerequisites 🛠
- .NET 6.0 onwards
- Visual Studio 2022

## Getting Started 🚀

**Clone the repository:**
```bash```
https: git clone [https://github.com/Choki12/WeatherApp.git]
```bash```
SSH: git clone [git@github.com:Choki12/WeatherApp.git]

## Set WeatherReportApp as the startup project

Make sure that `WeatherReportApp` is set as the startup project in Visual Studio. This ensures that the right project is executed when you run the solution.

## Run the application

1. Press `F5` or click on the `Run` button in Visual Studio.
2. The console will prompt you to input a city name.
3. Once provided, the app fetches the weather data for that city and saves it as a PDF. The report will be saved in this directory.

## Features 🌟

- **Weather Data Fetching:** Leverages the Weatherstack API to get real-time weather data.
- **PDF Generation:** Creates a well-formatted PDF report with the fetched weather data.

## Contribution 🤝

Pull requests are welcome! For major changes, please open an issue first to discuss what you'd like to change.

## License ⚖️

This project is licensed under the GNU GPL License.
