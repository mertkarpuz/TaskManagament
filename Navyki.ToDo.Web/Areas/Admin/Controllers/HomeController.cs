using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.Entities.Concrete;

namespace Navyki.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;

        public HomeController(IWorkService workService, INotificationService notificationService, UserManager<AppUser> userManager, IReportService reportService)
        {
            _workService = workService;
            _notificationService = notificationService;
            _userManager = userManager;
            _reportService = reportService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Active"] = "home";
            ViewBag.WillBeAssignWorks = _workService.GetWillBeAssignWorkCountWith();
            ViewBag.CompletedWorks = _workService.GetCompletedWorks();
            ViewBag.NotReadedNotificationCount = _notificationService.GetNonReadedNotificationCountWithAppUserId(user.Id);
            ViewBag.TotalReportCount = _reportService.GetReportCount();
            return View();
        }
    }
}
