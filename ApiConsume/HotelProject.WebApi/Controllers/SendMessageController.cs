using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.SendMessageDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SendMessageController : ControllerBase
{
    private readonly ISendMessageService _sendMessageService;
    private readonly IMapper _mapper;

    public SendMessageController(ISendMessageService sendMessageService, IMapper mapper)
    {
        _sendMessageService = sendMessageService;
        _mapper = mapper;
    }

    // GET: api/<SendMessageController>
    [HttpGet]
    public IActionResult SendMessageList()
    {
        var values = _sendMessageService.TGetList();
        var mappedValues = _mapper.Map<List<SendMessageDto>>(values);
        return Ok(mappedValues);
    }
    [HttpGet("GetSendMessageCount")]
    public IActionResult GetSendMessageCount()
    {
        var count = _sendMessageService.TGetSendMessageCount();
        return Ok(count);
    }

    // GET api/<SendMessageController>/5
    [HttpGet("{id}")]
    public IActionResult GetSendMessage(int id)
    {
        var value = _sendMessageService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<SendMessageController>
    [HttpPost]
    public IActionResult CreateSendMessage(CreateSendMessageDto createSendMessageDto)
    {
        var value = _mapper.Map<SendMessage>(createSendMessageDto);
        _sendMessageService.TInsert(value);
        return Ok("SendMessage added.");
    }

    // PUT api/<SendMessageController>/5
    [HttpPut]
    public IActionResult UpdateSendMessage(SendMessageDto SendMessageDto)
    {
        var value = _mapper.Map<SendMessage>(SendMessageDto);
        _sendMessageService.TUpdate(value);
        return Ok("SendMessage updated.");
    }

    // DELETE api/<SendMessageController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteSendMessage(int id)
    {
        var value = _sendMessageService.TGetByID(id);
        _sendMessageService.TDelete(value);
        return Ok("SendMessage deleted.");
    }
}
