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
using Navyki.ToDo.Web.StringInfo;

namespace Navyki.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IWorkService _workService;
        private readonly INotificationService _notificationService;
        private readonly IReportService _reportService;

        public HomeController(IWorkService workService, INotificationService notificationService, UserManager<AppUser> userManager, IReportService reportService) :base(userManager)
        {
            _workService = workService;
            _notificationService = notificationService;
            _reportService = reportService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await GetLogginedUser();
            TempData["Active"] = TempdataInfo.Home;
            ViewBag.WillBeAssignWorks = _workService.GetWillBeAssignWorkCountWith();
            ViewBag.CompletedWorks = _workService.GetCompletedWorks();
            ViewBag.NotReadedNotificationCount = _notificationService.GetNonReadedNotificationCountWithAppUserId(user.Id);
            ViewBag.TotalReportCount = _reportService.GetReportCount();
            return View();
        }
    }
}
