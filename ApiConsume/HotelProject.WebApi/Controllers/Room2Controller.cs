using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Room2Controller : ControllerBase
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;
    public Room2Controller(IRoomService roomService, IMapper mapper)
    {
        _roomService = roomService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var values = _roomService.TGetList();
        return Ok(values);
    }
    [HttpPost]
    public IActionResult AddRoom(CreateRoomDto createRoomDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var values = _mapper.Map<Room>(createRoomDto);
        _roomService.TInsert(values);
        return Ok("Room added.");

    }
    [HttpPut]
    public IActionResult UpdateRoom(RoomDto roomDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var values = _mapper.Map<Room>(roomDto);
        _roomService.TUpdate(values);
        return Ok("Room updated.");
    }
}
