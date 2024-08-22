using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DtoLayer.Dtos.AppUserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppUserWorkLocationController : ControllerBase
{
    private readonly Context _context;

    public AppUserWorkLocationController(Context context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult UserListWithWorkLocation()
    {
        var values = _context.Users.Include(x => x.WorkLocation).Select(y => new AppUserWithWorkLocationDto
        {
            Name = y.Name,
            Surname = y.Surname,
            WorkLocationName = y.WorkLocation.WorkLocationName,
            WorkLocationID = y.WorkLocationID.Value
        }).ToList();
        return Ok(values);
    }

}
