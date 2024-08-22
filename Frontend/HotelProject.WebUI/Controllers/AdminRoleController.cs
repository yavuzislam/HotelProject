using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RoleDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebUI.Controllers;

public class AdminRoleController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;

    public AdminRoleController(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        var values = _roleManager.Roles.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
    {
        var appRole = new AppRole
        {
            Name = createRoleDto.RoleName
        };

        var result = await _roleManager.CreateAsync(appRole);
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateRole(int id)
    {
        var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
        var updateRoleDto = new UpdateRoleDto
        {
            RoleID = value.Id,
            RoleName = value.Name
        };
        return View(updateRoleDto);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
    {
        var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == updateRoleDto.RoleID);
        value.Name = updateRoleDto.RoleName;
        await _roleManager.UpdateAsync(value);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteRole(int id)
    {
        var value = await _roleManager.FindByIdAsync(id.ToString());
        await _roleManager.DeleteAsync(value);
        return RedirectToAction("Index");
    }
}
