using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace HotelProject.WebUI.Controllers;

public class DefaultController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DefaultController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public PartialViewResult _SubscribePartial()
    {
        return PartialView();
    }

    [HttpPost]
    public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
    {
        var client = _httpClientFactory.CreateClient("");
        var jsonData = JsonSerializer.Serialize(createSubscribeDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        await client.PostAsync("https://localhost:7180/api/Subscribe", content);
        return RedirectToAction("Index", "Default");
    }
}
