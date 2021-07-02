using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.BaseControllers;

namespace Navyki.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : BaseIdentityController
    {
        private readonly IReportService _reportService;
        private readonly IWorkService _workService;
        private readonly INotificationService _notificationService;
        public HomeController(IReportService reportService, UserManager<AppUser> userManager, IWorkService workService, INotificationService notificationService):base(userManager)
        {
            _reportService = reportService;
            _workService = workService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await GetLogginedUser();
            TempData["Active"] = "home";
            ViewBag.ReportCount = _reportService.GetReportCountWithAppUserId(user.Id);
            ViewBag.CompletedWorks = _workService.GetWorkCountCompletedWithAppUserId(user.Id);
            ViewBag.NotCompletedWorkCount = _workService.GetWorkCountNonCompletedWithAppUserId(user.Id);
            ViewBag.NotReadedNotifications = _notificationService.GetNonReadedNotificationCountWithAppUserId(user.Id);
            return View();
        }
    }
}
