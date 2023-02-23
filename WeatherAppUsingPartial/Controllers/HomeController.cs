using WeatherAppUsingPartial.Models;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAppUsingPartial.Controllers
{
    public class HomeController : Controller
    {
        [Route("weather")]
        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> cities = new List<CityWeather>()
            {
                new CityWeather() {CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
                new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
            };


            return View(cities); //cities is passed to Model 
        }


        [Route("/weather/{cityCode}")]
        public IActionResult Details(string? cityCode)
        {
            if (cityCode is null)
            {
                return Content("City Code cannot be null!");
            }

            List<CityWeather> cities = new List<CityWeather>()
            {
                new CityWeather() {CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
                new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
            };

            CityWeather? matchCities = cities.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();
            //ViewBag.selection = matchCities; //only matched city will be sent to the view.Since we use ViewBag we can access the data from view easily. 

            return View(matchCities);
        }
    }
}
