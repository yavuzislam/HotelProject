﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;


namespace WebApiJwt.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefaultController : ControllerBase
{
    [HttpGet("[action]")]
    public IActionResult Test()
    {
        return Ok(new CreateToken().TokenCreate());
    }

    [HttpGet("[action]")]
    public IActionResult AdminToken()
    {
        return Ok(new CreateToken().TokenCreateAdmin());
    }

    [Authorize]
    [HttpGet("[action]")]
    public IActionResult Test2()
    {
        return Ok("Test2");
    }

    [Authorize]
    [HttpPost]
    public IActionResult Post()
    {
        return Ok("Post");
    }

    [Authorize(Roles = "Admin,Visitor")]
    [HttpGet("[action]")]
    public IActionResult Test3()
    {
        return Ok("Test3");
    }

}
