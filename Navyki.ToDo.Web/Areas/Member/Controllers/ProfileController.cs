using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.Areas.Member.Models;

namespace Navyki.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profile";
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListVM model = new AppUserListVM
            {
                Id = appUser.Id,
                Name = appUser.Name,
                Surname = appUser.Surname,
                Picture = appUser.Picture,
                Email = appUser.Email
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListVM model, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                var willBeUpdatedUser = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);
                if (Image != null)
                {
                    string url = Path.GetExtension(Image.FileName);
                    string imageName = Guid.NewGuid()+url;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + imageName);
                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }

                    willBeUpdatedUser.Picture = imageName;
                }
                willBeUpdatedUser.Name = model.Name;
                willBeUpdatedUser.Surname = model.Surname;
                willBeUpdatedUser.Email = model.Email;
                var result = await _userManager.UpdateAsync(willBeUpdatedUser);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işleminiz başarı ile gerçekleşti";
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
