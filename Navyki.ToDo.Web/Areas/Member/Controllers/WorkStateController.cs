using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DTO.DTOs.WorkDtos;
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
        private readonly IMapper _mapper;
        public WorkStateController(IWorkService workService, UserManager<AppUser> userManager,IMapper mapper)
        {
            _workService = workService;
            _mapper = mapper;
            _userManager = userManager; 
        }
        public async Task <IActionResult> Index(int activePage=1)
        {
            TempData["Active"] = "Complete";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            int totalPage;
            var works = _mapper.Map<List<WorkListAllDto>>(_workService.GetWillAllTablesUnComp(out totalPage, user.Id, activePage));

            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;



            return View(works);
        }
    }
}
