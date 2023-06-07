using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace Weather
{
    public partial class MainWindow : Window
    {
        private const string ApiKey = "ENTER_API_KEY";
        private const string ApiUrl = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&lang=ru";

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string city = CityTextBox.Text;
            string url = string.Format(ApiUrl, city, ApiKey);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    dynamic weatherData = JsonConvert.DeserializeObject(responseBody);
                    string description = weatherData.weather[0].description;
                    double temperature = weatherData.main.temp;

                    string emoji = "";
                    if (description.Contains("дождь"))
                    {
                        emoji = "🌧️";
                    }
                    else if (description.Contains("облачно"))
                    {
                        emoji = "☁️";
                    }
                    else if (description.Contains("снег"))
                    {
                        emoji = "❄️";
                    }
                    else if (description.Contains("ясно"))
                    {
                        emoji = "☀️";
                    }
                    WeatherTextBlock.Text = $"Погода в городе {city}: \nТемпература {temperature}°C, \n{description} {emoji}";
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Ошибка при получении данных о погоде: {ex.Message}");
                }
            }
        }
    }
}
