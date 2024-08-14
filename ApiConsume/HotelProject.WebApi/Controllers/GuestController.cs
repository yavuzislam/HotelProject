using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.GuestDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuestController : ControllerBase
{
    private readonly IGuestService _guestService;
    private readonly IMapper _mapper;

    public GuestController(IGuestService GuestService, IMapper mapper)
    {
        _guestService = GuestService;
        _mapper = mapper;
    }

    // GET: api/<GuestController>
    [HttpGet]
    public IActionResult GuestList()
    {
        var values = _guestService.TGetList();
        var mappedValues = _mapper.Map<List<GuestDto>>(values);
        return Ok(mappedValues);
    }

    // GET api/<GuestController>/5
    [HttpGet("{id}")]
    public IActionResult GetGuest(int id)
    {
        var value = _guestService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<GuestController>
    [HttpPost]
    public IActionResult CreateGuest(CreateGuestDto createGuestDto)
    {
        var value = _mapper.Map<Guest>(createGuestDto);
        _guestService.TInsert(value);
        return Ok("Guest added.");
    }

    // PUT api/<GuestController>/5
    [HttpPut]
    public IActionResult UpdateGuest(GuestDto guestDto)
    {
        var value = _mapper.Map<Guest>(guestDto);
        _guestService.TUpdate(value);
        return Ok("Guest updated.");
    }

    // DELETE api/<GuestController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteGuest(int id)
    {
        var value = _guestService.TGetByID(id);
        _guestService.TDelete(value);
        return Ok("Guest deleted.");
    }
}
