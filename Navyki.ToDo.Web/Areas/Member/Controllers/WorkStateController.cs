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
using Navyki.ToDo.Web.BaseControllers;
using Navyki.ToDo.Web.StringInfo;

namespace Navyki.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(RoleInfo.Member)]
    public class WorkStateController : BaseIdentityController
    {
        public readonly IWorkService _workService;
        private readonly IMapper _mapper;
        public WorkStateController(IWorkService workService, UserManager<AppUser> userManager,IMapper mapper):base(userManager)
        {
            _workService = workService;
            _mapper = mapper;
        }
        public async Task <IActionResult> Index(int activePage=1)
        {
            TempData["Active"] = TempdataInfo.WorkAdding;
            var user = await GetLogginedUser();
            var works = _mapper.Map<List<WorkListAllDto>>(_workService.GetWillAllTablesUnComp(out int totalPage, user.Id, activePage));

            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;



            return View(works);
        }
    }
}
