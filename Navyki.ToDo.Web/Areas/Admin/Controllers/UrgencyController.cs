using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.Areas.Admin.Models;
using System.Collections.Generic;

namespace Navyki.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        public UrgencyController(IUrgencyService urgencyService)
        {
            _urgencyService = urgencyService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "urgency";
            List<Urgency> Urgencies = _urgencyService.GetAll();
            List<UrgencyListVM> model = new List<UrgencyListVM>();
            foreach (var item in Urgencies)
            {
                UrgencyListVM urgencyModel = new UrgencyListVM();
                urgencyModel.Id = item.Id;
                urgencyModel.Description = item.Description;
                model.Add(urgencyModel);
            }
            return View(model);
        }


        public IActionResult AddUrgency()
        {
            TempData["Active"] = "urgency";
            return View(new UrgencyAddVM());
        }
        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddVM model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Create(
                new Urgency()
                {
                    Description = model.Description
                }
                );
                return RedirectToAction("Index");
            }
            return View(model);
        }



        public IActionResult UpdateUrgency(int id)
        {
            TempData["Active"] = "urgency";
            var urgency = _urgencyService.GetById(id);
            UrgencyUpdateVM model = new UrgencyUpdateVM
            {
                Id = urgency.Id,
                Description = urgency.Description

            };
            return View(model);
        }


        [HttpPost]
        public IActionResult UpdateUrgency(UrgencyUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Update(new Urgency
                {
                    Id = model.Id,
                    Description = model.Description

                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
