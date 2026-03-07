function checkWeather()
{
let city = document.getElementById("cityInput").value;
let result = document.getElementById("weatherResult");
let body = document.getElementById("body");

let weather;
let temp;
let icon;

/* Mock weather conditions */
let random = Math.floor(Math.random()*3);

if(random === 0)
{
weather = "Sunny";
temp = "28°C";
icon = "☀️";
body.style.background = "linear-gradient(120deg,#fddb92,#f6d365)";
}
else if(random === 1)
{
weather = "Rainy";
temp = "20°C";
icon = "🌧";
body.style.background = "linear-gradient(120deg,#4facfe,#00f2fe)";
}
else
{
weather = "Cloudy";
temp = "23°C";
icon = "☁️";
body.style.background = "linear-gradient(120deg,#bdc3c7,#2c3e50)";
}

result.innerHTML =
`
<div class="weather-icon">${icon}</div>
<h3>City: ${city}</h3>
<p>Temperature: ${temp}</p>
<p>Condition: ${weather}</p>
`;
}