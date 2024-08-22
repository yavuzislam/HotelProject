using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard;

public class _DashboardLast4StaffListPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DashboardLast4StaffListPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7180/api/Staff/GetLast4Staff");
        if (responseMessage.IsSuccessStatusCode)
        {
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultLast4StaffDto>>();
            return View(values);
        }
        return View();
    }
}
