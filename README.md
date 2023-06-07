# WeatherApp
Этот код представляет собой простое приложение для отображения погоды в заданном городе на языке C#. 
Он использует API OpenWeatherMap для получения данных о погоде и отображает их в окне приложения.
Для использования этого приложения необходимо иметь ключ API OpenWeatherMap. 
Ключ должен быть указан в переменной ApiKey. 
Также необходимо указать URL-адрес API OpenWeatherMap в переменной ApiUrl.
Приложение содержит класс MainWindow, который наследуется от класса Window. 
Он содержит метод SearchButton_Click, который вызывается при нажатии на кнопку "Поиск". 
В этом методе приложение получает данные о погоде для заданного города, использу API OpenWeatherMap. 
Затем оно отображает полученные данные в текстовом блоке WeatherTextBlock.
Для получения данных о погоде приложение отправляет GET-запрос на URL-адрес API OpenWeatherMap, используя объект HttpClient. 
Ответ от сервера десериализуется в объект dynamic, который содержит информацию о погоде. 
Затем приложение извлекает из этого объекта описание погоды и температуру, и отображает их в текстовом блоке WeatherTextBlock.
Код также содержит несколько условных операторов, которые определяют, какой эмодзи нужно отобразить в зависимости от описания погоды.
Для использования этого приложения необходимо иметь среду разработки Visual Studio и установить библиотеку Newtonsoft.Json.