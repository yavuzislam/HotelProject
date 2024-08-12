using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    // GET: api/<CustomerController>
    [HttpGet]
    public IActionResult CustomerList()
    {
        var values = _customerService.TGetList();
        return Ok(values);
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        var value = _customerService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<CustomerController>
    [HttpPost]
    public IActionResult CreateCustomer(Customer Customer)
    {
        _customerService.TInsert(Customer);
        return Ok("Customer added.");
    }

    // PUT api/<CustomerController>/5
    [HttpPut]
    public IActionResult UpdateCustomer(Customer Customer)
    {
        _customerService.TUpdate(Customer);
        return Ok("Customer updated.");
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var value = _customerService.TGetByID(id);
        _customerService.TDelete(value);
        return Ok("Customer deleted.");
    }
}
