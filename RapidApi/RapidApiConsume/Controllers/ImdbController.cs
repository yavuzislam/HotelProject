using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers;

public class ImdbController : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
            Headers =
    {
        { "x-rapidapi-key", "7e9f994fc5mshf035cdcd0a340c9p1313eejsnd5ff148195a2" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
            return View(value);
        }
    }
}
