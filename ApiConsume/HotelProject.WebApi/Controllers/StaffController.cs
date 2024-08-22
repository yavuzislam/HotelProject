using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IStaffService _staffService;

    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }

    // GET: api/<StaffController>
    [HttpGet]
    public IActionResult StaffList()
    {
        var values = _staffService.TGetList();
        return Ok(values);
    }

    // GET api/<StaffController>/5
    [HttpGet("{id}")]
    public IActionResult GetStaff(int id)
    {
        var value = _staffService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<StaffController>
    [HttpPost]
    public IActionResult CreateStaff(Staff staff)
    {
        _staffService.TInsert(staff);
        return Ok("Staff added.");
    }

    // PUT api/<StaffController>/5
    [HttpPut]
    public IActionResult UpdateStaff(Staff staff)
    {
        _staffService.TUpdate(staff);
        return Ok("Staff updated.");
    }

    // DELETE api/<StaffController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteStaff(int id)
    {
        var value = _staffService.TGetByID(id);
        _staffService.TDelete(value);
        return Ok("Staff deleted.");
    }

    [HttpGet("GetLast4Staff")]
    public IActionResult GetLast4Staff()
    {
        var values = _staffService.TGetLast4Staff();
        return Ok(values);
    }

}
