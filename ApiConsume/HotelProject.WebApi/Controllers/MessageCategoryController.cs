using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageCategoryController : ControllerBase
{
    private readonly IMessageCategoryService _messageCategoryService;

    public MessageCategoryController(IMessageCategoryService messageCategoryService)
    {
        _messageCategoryService = messageCategoryService;
    }

    // GET: api/<MessageCategoryController>
    [HttpGet]
    public IActionResult MessageCategoryList()
    {
        var values = _messageCategoryService.TGetList();
        return Ok(values);
    }

    // GET api/<MessageCategoryController>/5
    [HttpGet("{id}")]
    public IActionResult GetMessageCategory(int id)
    {
        var value = _messageCategoryService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<MessageCategoryController>
    [HttpPost]
    public IActionResult CreateMessageCategory(MessageCategory messageCategory)
    {
        _messageCategoryService.TInsert(messageCategory);
        return Ok("MessageCategory added.");
    }

    // PUT api/<MessageCategoryController>/5
    [HttpPut]
    public IActionResult UpdateMessageCategory(MessageCategory messageCategory)
    {
        _messageCategoryService.TUpdate(messageCategory);
        return Ok("MessageCategory updated.");
    }

    // DELETE api/<MessageCategoryController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteMessageCategory(int id)
    {
        var value = _messageCategoryService.TGetByID(id);
        _messageCategoryService.TDelete(value);
        return Ok("MessageCategory deleted.");
    }
}
