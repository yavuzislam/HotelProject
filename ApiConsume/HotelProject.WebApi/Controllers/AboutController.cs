using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly IAboutService _AboutService;

    public AboutController(IAboutService AboutService)
    {
        _AboutService = AboutService;
    }

    // GET: api/<AboutController>
    [HttpGet]
    public IActionResult AboutList()
    {
        var values = _AboutService.TGetList();
        return Ok(values);
    }

    // GET api/<AboutController>/5
    [HttpGet("{id}")]
    public IActionResult GetAbout(int id)
    {
        var value = _AboutService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<AboutController>
    [HttpPost]
    public IActionResult CreateAbout(About About)
    {
        _AboutService.TInsert(About);
        return Ok("About added.");
    }

    // PUT api/<AboutController>/5
    [HttpPut]
    public IActionResult UpdateAbout(About About)
    {
        _AboutService.TUpdate(About);
        return Ok("About updated.");
    }

    // DELETE api/<AboutController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteAbout(int id)
    {
        var value = _AboutService.TGetByID(id);
        _AboutService.TDelete(value);
        return Ok("About deleted.");
    }

    [HttpGet("GetLastAbout")]
    public IActionResult GetLastAbout()
    {
        var value = _AboutService.GetLastAbout();
        return Ok(value);
    }
}
