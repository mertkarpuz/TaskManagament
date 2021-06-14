 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.Areas.Admin.Models;

namespace Navyki.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class WorkController : Controller
    {

        private readonly IWorkService _workService;
        private readonly IUrgencyService _urgencyService;
        public WorkController(IWorkService workService, IUrgencyService urgencyService)
        {
            _urgencyService = urgencyService;
            _workService = workService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "work";
            List<Work> works = _workService.GetWithUrgencyUnComp();
            List<WorkListVM> models = new List<WorkListVM>();
            foreach (var item in works)
            {
                WorkListVM model = new WorkListVM
                {
                    Description = item.Description,
                    Urgency = item.Urgency,
                    UrgencyId = item.UrgencyId,
                    Name = item.Name,
                    State = item.State,
                    Id = item.Id,
                    CreatedTime = item.CreatedTime
                };
                models.Add(model);
            }
            return View(models);
        }

        public IActionResult AddWork()
        {
            TempData["Active"] = "work";
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description");
            return View(new WorkAddVM());
        }

        [HttpPost]
        public IActionResult AddWork(WorkAddVM model)
        {
            if (ModelState.IsValid)
            {
                _workService.Create(new Work
                {
                    Description = model.Description,
                    Name = model.Name,
                    UrgencyId = model.UrgencyId,

                });
                return RedirectToAction("Index");
            }
            return View(model);
        }



        public IActionResult UpdateWork(int id)
        {
            TempData["Active"] = "work";
            var work = _workService.GetById(id);
            WorkUpdateVM model = new WorkUpdateVM()
            {
                Id = work.Id,
                Description = work.Description,
                UrgencyId = work.UrgencyId,
                Name = work.Name
            };
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description",work.UrgencyId);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateWork(WorkUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                _workService.Update(new Work
                {
                    Id=model.Id,
                    Description = model.Description,
                    UrgencyId = model.Id,
                    Name=model.Name
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public IActionResult DeleteWork(int id)
        {
            _workService.Delete(new Work { Id = id });
            return Json(null);
        }

    }
}
