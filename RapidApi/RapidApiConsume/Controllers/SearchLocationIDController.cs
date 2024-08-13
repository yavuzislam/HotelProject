using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers;

public class SearchLocationIDController : Controller
{
    public async Task<IActionResult> Index(string cityName)
    {
        if (!string.IsNullOrEmpty(cityName))
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                Headers =
    {
        { "x-rapidapi-key", "7e9f994fc5mshf035cdcd0a340c9p1313eejsnd5ff148195a2" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                return View(values.Take(1).ToList());
            }

        }
        else
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=paris&locale=en-gb"),
                Headers =
    {
        { "x-rapidapi-key", "7e9f994fc5mshf035cdcd0a340c9p1313eejsnd5ff148195a2" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                return View(values.Take(1).ToList());
            }
        }
    }
}

//RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Paris&locale=en-gb"),