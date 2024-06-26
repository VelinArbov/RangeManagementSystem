﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RangeManagementSystem.Data.Models;
using RangeManagementSystem.Data;
using RangeManagementSystem.Web.Models;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace RangeManagementSystem.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public LoginController(RangeManagementSystemDbContext dbContext,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, lockoutOnFailure: true);
                var user = await this._userManager.FindByNameAsync(model.Username);
                if (result.Succeeded && user != null)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    ViewData["UserId"] = userId;
                    if (user.IsAdmin)
                    {
                        return RedirectToAction("Dashboard", "Admin");  
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Client");
                    }
                }
            }

            return View("Index", model);
        }

        [Authorize]
        public async Task<IActionResult> Logout(string userId)
        {
            // Sign out the user
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // Redirect to a specific page after sign out
        }
    }
}
