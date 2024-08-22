using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.AppUserDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppUserController : ControllerBase
{
    private readonly IAppUserService _AppUserService;
    private readonly IMapper _mapper;

    public AppUserController(IAppUserService AppUserService, IMapper mapper)
    {
        _AppUserService = AppUserService;
        _mapper = mapper;
    }

    // GET: api/<AppUserController>
    [HttpGet]
    public IActionResult AppUserList()
    {
        var values = _AppUserService.TGetList();
        return Ok(values);
    }

    // GET api/<AppUserController>/5
    [HttpGet("{id}")]
    public IActionResult GetAppUser(int id)
    {
        var value = _AppUserService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<AppUserController>
    [HttpPost]
    public IActionResult CreateAppUser(AppUser AppUser)
    {
        _AppUserService.TInsert(AppUser);
        return Ok("AppUser added.");
    }

    // PUT api/<AppUserController>/5
    [HttpPut]
    public IActionResult UpdateAppUser(AppUser AppUser)
    {
        _AppUserService.TUpdate(AppUser);
        return Ok("AppUser updated.");
    }

    // DELETE api/<AppUserController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteAppUser(int id)
    {
        var value = _AppUserService.TGetByID(id);
        _AppUserService.TDelete(value);
        return Ok("AppUser deleted.");
    }
    [HttpGet("GetAppUsers")]
    public IActionResult GetAppUsers()
    {
        var values = _AppUserService.TGetAppUsers();
        return Ok(values);
    }

    [HttpGet("GetAppUsersWithLocation")]
    public IActionResult GetAppUsersWithLocation()
    {
        var values = _AppUserService.TGetAppUsersWithLocation();
        
        return Ok(values);
    }
}
