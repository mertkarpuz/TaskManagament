using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DTO.DTOs.UrgencyDtos;
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
        private readonly IMapper _mapper;
        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "urgency";
            return View(_mapper.Map<List<UrgencyListDto>>(_urgencyService.GetAll()));
        }


        public IActionResult AddUrgency()
        {
            TempData["Active"] = "urgency";
            return View(new UrgencyAddDto());
        }
        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddDto model)
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
            return View(_mapper.Map<UrgencyUpdateDto>(_urgencyService.GetById(id)));
        }


        [HttpPost]
        public IActionResult UpdateUrgency(UrgencyUpdateDto model)
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
