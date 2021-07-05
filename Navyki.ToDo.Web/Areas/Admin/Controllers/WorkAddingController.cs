using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DTO.DTOs.AppUserDtos;
using Navyki.Todo.DTO.DTOs.ReportDtos;
using Navyki.Todo.DTO.DTOs.WorkDtos;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.StringInfo;

namespace Navyki.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class WorkAddingController : Controller
    {
        public readonly IAppUserService _appUserService;
        public readonly IWorkService _workService;
        public readonly UserManager<AppUser> _userManager;
        public readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public WorkAddingController(IAppUserService appUserService, IWorkService workService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService, IMapper mapper)
        {
            _appUserService = appUserService;
            _workService = workService;
            _userManager = userManager;
            _mapper = mapper;
            _fileService = fileService;
            _notificationService = notificationService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.WorkAdding;
            return View(_mapper.Map<List<WorkListAllDto>>(_workService.GetAllWithTables()));
        }


        public IActionResult AssignMember(int id, string s, int page = 1)
        {
            TempData["Active"] = TempdataInfo.WorkAdding;
            ViewBag.activePage = page;
            //ViewBag.TotalPage = (int)Math.Ceiling((double)_appUserService.GetNotAdmin().Count / 3);
            var members = _mapper.Map<List<AppUserListDto>>(_appUserService.GetNotAdmin(out int totalPage, s, page));
            ViewBag.TotalPage = totalPage;
            ViewBag.Searched = s;
            ViewBag.Members = members;
            return View(_mapper.Map<WorkListDto>(_workService.GetUrgencyWithId(id)));
        }


        [HttpPost]
        public IActionResult AssignMember(MemberWorkAssignDto model)
        {
            TempData["Active"] = TempdataInfo.WorkAdding;
            var willBeUpdateWork = _workService.GetById(model.WorkId);
            willBeUpdateWork.AppUserId = model.MemberId;

            _notificationService.Create(new Notification
            {
                AppUserId = model.MemberId,
                Description = $"{willBeUpdateWork.Name} adlı iş için görevlendirildiniz."

            });

            _workService.Update(willBeUpdateWork);
            return RedirectToAction("Index");
        }



        public IActionResult Details(int id)
        {
            TempData["Active"] = TempdataInfo.WorkAdding;

            return View(_mapper.Map<WorkListAllDto>(_workService.GetWReportsWId(id)));
        }






        public IActionResult WorkAssignMember(MemberWorkAssignDto model)
        {
            TempData["Active"] = "workadding";
            MemberWorkAssignListDto memberAssignWorkModel = new MemberWorkAssignListDto
            {
                AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(x => x.Id == model.MemberId)),
                Work = _mapper.Map<WorkListDto>(_workService.GetUrgencyWithId(model.WorkId))
            };


            return View(memberAssignWorkModel);
        }

        public IActionResult GetExcel(int id)
        {
            return File(_fileService.TransferExcel(_mapper.Map<List<ReportFileDto>>(_workService.GetWReportsWId(id).Reports)), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult GetPdf(int id)
        {
            var path = _fileService.TransferPdf(_mapper.Map<List<ReportFileDto>>(_workService.GetWReportsWId(id).Reports));
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}
