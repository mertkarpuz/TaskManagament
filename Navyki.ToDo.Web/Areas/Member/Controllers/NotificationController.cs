using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.Areas.Member.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles ="Member")]
    [Area("Member")]

    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "notification";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var notifications = _notificationService.GetNotReaded(user.Id);
            List<NotificationListViewModel> models = new List<NotificationListViewModel>();
            foreach (var item in notifications)
            {
                NotificationListViewModel model = new NotificationListViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                models.Add(model);
            }
            return View(models);
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
