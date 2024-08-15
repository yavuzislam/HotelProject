using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.ContactDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    private readonly IMapper _mapper;

    public ContactController(IContactService contactService, IMapper mapper)
    {
        _contactService = contactService;
        _mapper = mapper;
    }

    // GET: api/<ContactController>
    [HttpGet]
    public IActionResult ContactList()
    {
        var values = _contactService.TGetList();
        return Ok(values);
    }

    [HttpGet("GetContactCount")]
    public IActionResult GetContactCount()
    {
        var count = _contactService.TGetContactCount();
        return Ok(count);
    }

    // GET api/<ContactController>/5
    [HttpGet("{id}")]
    public IActionResult GetContact(int id)
    {
        var value = _contactService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<ContactController>
    [HttpPost]
    public IActionResult CreateContact(CreateContactDto createContactDto)
    {
        createContactDto.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
        var contact = _mapper.Map<Contact>(createContactDto);
        _contactService.TInsert(contact);
        return Ok("Contact added.");
    }

    // PUT api/<ContactController>/5
    [HttpPut]
    public IActionResult UpdateContact(Contact Contact)
    {
        _contactService.TUpdate(Contact);
        return Ok("Contact updated.");
    }

    // DELETE api/<ContactController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteContact(int id)
    {
        var value = _contactService.TGetByID(id);
        _contactService.TDelete(value);
        return Ok("Contact deleted.");
    }

    [HttpGet("GetContactByCategory")]
    public IActionResult GetContactByCategory(int id)
    {
        var value = _contactService.TGetContactByCategory(id);
        return Ok(value);
    }
}
