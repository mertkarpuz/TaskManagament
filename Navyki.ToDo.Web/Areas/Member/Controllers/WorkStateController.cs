using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.Areas.Member.Models;

namespace Navyki.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles ="Member")]
    [Area("Member")]
    public class WorkStateController : Controller
    {
        public readonly IWorkService _workService;
        private readonly UserManager<AppUser> _userManager;
        public WorkStateController(IWorkService workService, UserManager<AppUser> userManager)
        {
            _workService = workService;
            _userManager = userManager; 
        }
        public async Task <IActionResult> Index(int activePage=1)
        {
            TempData["Active"] = "Complete";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            int totalPage;
            var works = _workService.GetWillAllTablesUnComp(out totalPage, user.Id, activePage);

            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;


            List<WorkListAllVM> models = new List<WorkListAllVM>();
            foreach (var item in works)
            {
                WorkListAllVM model = new WorkListAllVM();
                model.Id = item.Id;
                model.Description = item.Description;
                model.Urgency = item.Urgency;
                model.Name = item.Name;
                model.AppUser = item.AppUser;
                model.CreatedTime = item.CreatedTime;
                model.Reports = item.Reports;
                models.Add(model);
            }

            return View(models);
        }
    }
}
