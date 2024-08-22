using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RoleDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebUI.Controllers;

public class AdminRoleAssignController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public AdminRoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        var values = _userManager.Users.ToList();
        return View(values);
    }

    [HttpGet]
    public async Task<IActionResult> AssignRole(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        TempData["userid"] = user.Id;
        var roles = await _roleManager.Roles.ToListAsync();
        var userRoles = await _userManager.GetRolesAsync(user);
        var roleAssignDtos = new List<RoleAssignDto>();

        foreach (var item in roles)
        {
            var model = new RoleAssignDto
            {
                RoleID = item.Id,
                RoleName = item.Name,
                RoleExist = userRoles.Contains(item.Name)
            };
            roleAssignDtos.Add(model);
        }
        return View(roleAssignDtos);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRole(List<RoleAssignDto> roleAssignDtos)
    {
        var userId = (int)TempData["userid"];
        var user = await _userManager.FindByIdAsync(userId.ToString());
        foreach (var item in roleAssignDtos)
        {
            if (item.RoleExist)
            {
                await _userManager.AddToRoleAsync(user, item.RoleName);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, item.RoleName);
            }
        }
        return RedirectToAction("Index");
    }
}
