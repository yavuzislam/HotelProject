using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers;

public class AdminUserController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminUserController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("");
        var responseMessage = await client.GetAsync("https://localhost:7180/api/AppUser/GetAppUsers");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<AppUserWithWorkLocationDto>>(jsonData);
            return View(result);

        }
        return View();
    }
}
