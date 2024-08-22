﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers;

public class AdminSettingsController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public AdminSettingsController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var userEditViewModel = new UserEditViewModel
        {
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            Username = user.UserName
        };
        return View(userEditViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
    {
        if (userEditViewModel.Password == userEditViewModel.ConfirmPassword)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = userEditViewModel.Name;
            user.Surname = userEditViewModel.Surname;
            user.Email = userEditViewModel.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        return View();
    }
}
