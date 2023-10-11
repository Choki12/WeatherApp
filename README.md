# WeatherApp
I'm sorry Ms Jackson. You can plan a pretty picnic. But you can't predict the weather. I'm sorry Ms. Jackson (oh), I am for real..

This a .NET Core Console App that reads weather data from the weatherstack api (https://weatherstack.com).
The api is queried with a city name and the api key and the response is returned in JSON format and then deserialized into a data model (weather data) and parsed based on specific weather data required and then saved to a PDF File.
The entry point of the application is the console app, the user simply enters a city name and the weather data is saved locally to a PDF File prefixed with the city name.
