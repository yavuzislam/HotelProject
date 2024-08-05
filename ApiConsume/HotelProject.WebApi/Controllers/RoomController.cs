using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService RoomService)
    {
        _roomService = RoomService;
    }

    // GET: api/<RoomController>
    [HttpGet]
    public IActionResult RoomList()
    {
        var values = _roomService.TGetList();
        return Ok(values);
    }

    // GET api/<RoomController>/5
    [HttpGet("{id}")]
    public IActionResult GetRoom(int id)
    {
        var value = _roomService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<RoomController>
    [HttpPost]
    public IActionResult CreateRoom(Room Room)
    {
        _roomService.TInsert(Room);
        return Ok("Room added.");
    }

    // PUT api/<RoomController>/5
    [HttpPut]
    public IActionResult UpdateRoom(Room Room)
    {
        _roomService.TUpdate(Room);
        return Ok("Room updated.");
    }

    // DELETE api/<RoomController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteRoom(int id)
    {
        var value = _roomService.TGetByID(id);
        _roomService.TDelete(value);
        return Ok("Room deleted.");
    }
}
