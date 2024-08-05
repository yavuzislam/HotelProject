﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace HotelProject.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService ServiceService)
    {
        _serviceService = ServiceService;
    }

    // GET: api/<ServiceController>
    [HttpGet]
    public IActionResult ServiceList()
    {
        var values = _serviceService.TGetList();
        return Ok(values);
    }

    // GET api/<ServiceController>/5
    [HttpGet("{id}")]
    public IActionResult GetService(int id)
    {
        var value = _serviceService.TGetByID(id);
        return Ok(value);
    }

    // POST api/<ServiceController>
    [HttpPost]
    public IActionResult CreateService(Service Service)
    {
        _serviceService.TInsert(Service);
        return Ok("Service added.");
    }

    // PUT api/<ServiceController>/5
    [HttpPut]
    public IActionResult UpdateService(Service Service)
    {
        _serviceService.TUpdate(Service);
        return Ok("Service updated.");
    }

    // DELETE api/<ServiceController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteService(int id)
    {
        var value = _serviceService.TGetByID(id);
        _serviceService.TDelete(value);
        return Ok("Service deleted.");
    }
}
