 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DTO.DTOs.WorkDtos;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.StringInfo;

namespace Navyki.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class WorkController : Controller
    {

        private readonly IWorkService _workService;
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;
        public WorkController(IWorkService workService, IUrgencyService urgencyService , IMapper mapper)
        {
            _mapper = mapper;
            _urgencyService = urgencyService;
            _workService = workService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Work;
            return View(_mapper.Map<List<WorkListDto>>(_workService.GetWithUrgencyUnComp()));
        }

        public IActionResult AddWork()
        {
            TempData["Active"] = TempdataInfo.Work;
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description");
            return View(new WorkAddDto());
        }

        [HttpPost]
        public IActionResult AddWork(WorkAddDto model)
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
            TempData["Active"] = TempdataInfo.Work;
            var work = _workService.GetById(id);
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description",work.UrgencyId);
            return View(_mapper.Map<WorkUpdateDto>(work));
        }

        [HttpPost]
        public IActionResult UpdateWork(WorkUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _workService.Update(new Work
                {
                    Id=model.Id,
                    Description = model.Description,
                    UrgencyId = model.UrgencyId,
                    Name=model.Name
                });
                return RedirectToAction("Index");
            }
            ViewBag.Urgencies = new SelectList(_urgencyService.GetAll(), "Id", "Description", model.UrgencyId);
            return View(model);
        }


        public IActionResult DeleteWork(int id)
        {
            _workService.Delete(new Work { Id = id });
            return Json(null);
        }

    }
}
