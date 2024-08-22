﻿using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers;

public class AdminUserListWithWorkLocationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminUserListWithWorkLocationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> UserList()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7180/api/AppUserWorkLocation");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AppUserWithWorkLocationDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
