using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.ToDo.Web.StringInfo;
using Newtonsoft.Json;

namespace Navyki.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class GraphController : Controller
    {
        private readonly IAppUserService _appUserService;
        public GraphController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Graph;
            return View();
        }

        public IActionResult MostCompleted()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.MostWorkComplatedMembers());
            return Json(jsonString);
        }
        public IActionResult MostAssignedMember()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.MostWorkAssignedMembers());
            return Json(jsonString);
        }
    }
}
