using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard;

public class _DashboardLast6BookingsPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DashboardLast6BookingsPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7180/api/Booking/Last6Booking");
        if (responseMessage.IsSuccessStatusCode)
        {
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultBookingDto>>();
            return View(values);
        }
        return View();
    }

}
