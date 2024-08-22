using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.WorkLocationDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkLocationController : ControllerBase
{
    private readonly IWorkLocationService _workLocationService;
    private readonly IMapper _mapper;

    public WorkLocationController(IWorkLocationService WorkLocationService, IMapper mapper)
    {
        _workLocationService = WorkLocationService;
        _mapper = mapper;
    }

    // GET: api/<WorkLocationController>
    [HttpGet]
    public IActionResult WorkLocationList()
    {
        var values = _workLocationService.TGetList();
        return Ok(values);
    }

    // GET api/<WorkLocationController>/5
    [HttpGet("{id}")]
    public IActionResult GetWorkLocation(int id)
    {
        var value = _workLocationService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<WorkLocationController>
    [HttpPost]
    public IActionResult CreateWorkLocation(CreateWorkLocationDto createWorkLocationDto)
    {
        var value = _mapper.Map<WorkLocation>(createWorkLocationDto);
        _workLocationService.TInsert(value);
        return Ok("WorkLocation added.");
    }

    // PUT api/<WorkLocationController>/5
    [HttpPut]
    public IActionResult UpdateWorkLocation(WorkLocationDto workLocationDto)
    {
        var value = _mapper.Map<WorkLocation>(workLocationDto);
        _workLocationService.TUpdate(value);
        return Ok("WorkLocation updated.");
    }

    // DELETE api/<WorkLocationController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteWorkLocation(int id)
    {
        var value = _workLocationService.TGetByID(id);
        _workLocationService.TDelete(value);
        return Ok("WorkLocation deleted.");
    }

    //[HttpGet("GetWorkLocationsWithAppUsers")]
    //public IActionResult GetWorkLocationsWithAppUsers()
    //{
    //    var values = _workLocationService.TGetWorkLocationsWithAppUsers();
    //    return Ok(values);
    //}
}
