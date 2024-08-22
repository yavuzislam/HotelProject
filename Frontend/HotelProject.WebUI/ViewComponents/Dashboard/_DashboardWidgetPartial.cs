using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard;

public class _DashboardWidgetPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client1 = _httpClientFactory.CreateClient("");
        var response1 = await client1.GetAsync("https://localhost:7180/api/DashboardWidgets/StaffCount");
        if (response1.IsSuccessStatusCode)
        {
            var staffCount = await response1.Content.ReadAsStringAsync();
            ViewBag.StaffCount = staffCount;
        }

        var client2 = _httpClientFactory.CreateClient("");
        var response2 = await client2.GetAsync("https://localhost:7180/api/DashboardWidgets/RoomCount");
        if (response2.IsSuccessStatusCode)
        {
            var roomCount = await response2.Content.ReadAsStringAsync();
            ViewBag.RoomCount = roomCount;
        }

        var client3 = _httpClientFactory.CreateClient("");
        var response3 = await client3.GetAsync("https://localhost:7180/api/DashboardWidgets/BookingCount");
        if (response3.IsSuccessStatusCode)
        {
            var bookingCount = await response3.Content.ReadAsStringAsync();
            ViewBag.BookingCount = bookingCount;
        }

        var client4 = _httpClientFactory.CreateClient("");
        var response4 = await client4.GetAsync("https://localhost:7180/api/DashboardWidgets/AppUserCount");
        if (response4.IsSuccessStatusCode)
        {
            var appUserCount = await response4.Content.ReadAsStringAsync();
            ViewBag.AppUserCount = appUserCount;
        }
        return View();
    }
}
