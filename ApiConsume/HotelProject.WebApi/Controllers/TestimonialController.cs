using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialController : ControllerBase
{
    private readonly ITestimonialService _testimonialService;

    public TestimonialController(ITestimonialService TestimonialService)
    {
        _testimonialService = TestimonialService;
    }

    // GET: api/<TestimonialController>
    [HttpGet]
    public IActionResult TestimonialList()
    {
        var values = _testimonialService.TGetList();
        return Ok(values);
    }

    // GET api/<TestimonialController>/5
    [HttpGet("{id}")]
    public IActionResult GetTestimonial(int id)
    {
        var value = _testimonialService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<TestimonialController>
    [HttpPost]
    public IActionResult CreateTestimonial(Testimonial Testimonial)
    {
        _testimonialService.TInsert(Testimonial);
        return Ok("Testimonial added.");
    }

    // PUT api/<TestimonialController>/5
    [HttpPut]
    public IActionResult UpdateTestimonial(Testimonial Testimonial)
    {
        _testimonialService.TUpdate(Testimonial);
        return Ok("Testimonial updated.");
    }

    // DELETE api/<TestimonialController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteTestimonial(int id)
    {
        var value = _testimonialService.TGetByID(id);
        _testimonialService.TDelete(value);
        return Ok("Testimonial deleted.");
    }
}
