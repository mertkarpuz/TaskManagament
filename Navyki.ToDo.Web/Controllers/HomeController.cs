using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DTO.DTOs.AppUserDtos;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.Models;

namespace Navyki.ToDo.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Login(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                  var identityResult =  await _signInManager.PasswordSignInAsync(model.UserName,model.Password,model.RememberMe,false);
                  if (identityResult.Succeeded)
                  {
                       var roles = await _userManager.GetRolesAsync(user);
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index","Home",new {area="Admin"});
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                  }
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            }
            return View("Index",model);
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async  Task<IActionResult> Register(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser() {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname
                };
                var result = await _userManager.CreateAsync(user,model.Password);

                if (result.Succeeded)
                {
                  var AddRoleResult =  await _userManager.AddToRoleAsync(user, "Member");
                    if (AddRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    foreach (var item in AddRoleResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);

        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}
