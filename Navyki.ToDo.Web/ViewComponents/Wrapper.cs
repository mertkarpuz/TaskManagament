using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DTO.DTOs.AppUserDtos;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
       
        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var identityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserListDto>(identityUser);
            

            var notifications = _notificationService.GetNotReaded(model.Id).Count();

            ViewBag.NotificationCount = notifications;

            var roles = _userManager.GetRolesAsync(identityUser).Result;
            if (roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member",model);
        }
    }
}
