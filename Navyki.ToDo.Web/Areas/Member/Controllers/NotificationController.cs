using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DTO.DTOs.NotificationDtos;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.BaseControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles ="Member")]
    [Area("Member")]

    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "notification";
            var user = await GetLogginedUser();
            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.GetNotReaded(user.Id)));
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var willbeUpdatedNotification = _notificationService.GetById(id);
            willbeUpdatedNotification.State = true;
            _notificationService.Update(willbeUpdatedNotification);
            return RedirectToAction("Index");
        }


    }
}
