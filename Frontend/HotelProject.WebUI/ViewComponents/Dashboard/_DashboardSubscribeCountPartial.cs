using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard;

public class _DashboardSubscribeCountPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DashboardSubscribeCountPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/didemgeziyor"),
            Headers =
    {
        { "X-RapidAPI-Key", "630ce9cc86msh271c60cffe62d5ep1b514djsn0fe292593744" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var value = await response.Content.ReadFromJsonAsync<ResultInstagramFollowersDto>();
            ViewBag.v1 = value.followers;
            ViewBag.v2 = value.following;
        }

        var client2 = new HttpClient();
        var request2 = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=murattyucedag"),
            Headers =
    {
        { "X-RapidAPI-Key", "630ce9cc86msh271c60cffe62d5ep1b514djsn0fe292593744" },
        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    },
        };
        using (var response2 = await client2.SendAsync(request2))
        {
            response2.EnsureSuccessStatusCode();
            var value = await response2.Content.ReadFromJsonAsync<ResultTwittterFollowersDto>();
            ViewBag.v3 = value.data.user_info.followers_count;
            ViewBag.v4 = value.data.user_info.friends_count;
        }

        var client3 = new HttpClient();
        var request3 = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fmurat-y%C3%BCceda%C4%9F-186933149%2F"),
            Headers =
    {
        { "X-RapidAPI-Key", "630ce9cc86msh271c60cffe62d5ep1b514djsn0fe292593744" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
        };
        using (var response3 = await client3.SendAsync(request3))
        {
            response3.EnsureSuccessStatusCode();
            var value = await response3.Content.ReadFromJsonAsync<ResultLinkedinFollowersDto>();
            ViewBag.v5 = value.data.followers_count;
        }
        return View();
    }
}
