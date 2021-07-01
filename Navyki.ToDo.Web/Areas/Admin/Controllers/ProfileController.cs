using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.DTO.DTOs.AppUserDtos;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.Areas.Admin.Models;

namespace Navyki.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public ProfileController(UserManager<AppUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profile";
            return View(_mapper.Map<AppUserListDto>(await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile Image)
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
