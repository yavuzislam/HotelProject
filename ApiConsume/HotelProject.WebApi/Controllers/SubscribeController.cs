using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController : ControllerBase
{
    private readonly ISubscribeService _subscribeService;

    public SubscribeController(ISubscribeService SubscribeService)
    {
        _subscribeService = SubscribeService;
    }

    // GET: api/<SubscribeController>
    [HttpGet]
    public IActionResult SubscribeList()
    {
        var values = _subscribeService.TGetList();
        return Ok(values);
    }

    // GET api/<SubscribeController>/5
    [HttpGet("{id}")]
    public IActionResult GetSubscribe(int id)
    {
        var value = _subscribeService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<SubscribeController>
    [HttpPost]
    public IActionResult CreateSubscribe(Subscribe Subscribe)
    {
        _subscribeService.TInsert(Subscribe);
        return Ok("Subscribe added.");
    }

    // PUT api/<SubscribeController>/5
    [HttpPut]
    public IActionResult UpdateSubscribe(Subscribe Subscribe)
    {
        _subscribeService.TUpdate(Subscribe);
        return Ok("Subscribe updated.");
    }

    // DELETE api/<SubscribeController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteSubscribe(int id)
    {
        var value = _subscribeService.TGetByID(id);
        _subscribeService.TDelete(value);
        return Ok("Subscribe deleted.");
    }
}
