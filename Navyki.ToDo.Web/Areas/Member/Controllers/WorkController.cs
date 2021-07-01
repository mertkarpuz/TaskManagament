using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DTO.DTOs.ReportDtos;
using Navyki.Todo.DTO.DTOs.WorkDtos;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.Areas.Member.Models;

namespace Navyki.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public WorkController(IWorkService workService, UserManager<AppUser> userManager, IReportService reportService, INotificationService notificationService,IMapper mapper)
        {
            _workService = workService;
            _userManager = userManager;
            _mapper = mapper;
            _reportService = reportService;
            _notificationService = notificationService;
        }
        public async  Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Active"] = "works";
            


            return View(_mapper.Map<List<WorkListAllDto>>(_workService.GetAllWithTables(x => x.AppUserId == user.Id && !x.State)));
        }


        public IActionResult AddReport(int id)
        {
            TempData["Active"] = "works";
            var work = _workService.GetUrgencyWithId(id);
            ReportAddDto model = new ReportAddDto();
            model.Work = work;
            model.WorkId = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Create(new Report
                {
                    WorkId = model.WorkId,
                    Detail = model.Detail,
                    Description = model.Description
                });

                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");

                var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);

                foreach (var admin in adminUserList)
                {
                    _notificationService.Create(new Notification
                    {

                        Description = $"{activeUser.Name} {activeUser.Surname} yeni bir rapor yazdı",
                        AppUserId = admin.Id
                    });
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = "works";
            var report =_reportService.GetWithWork(id);
            ReportUpdateDto model = new ReportUpdateDto();
            model.Id = report.Id;
            model.Description = report.Description;
            model.Detail = report.Detail;
            model.Work = report.Work;
            model.WorkId = report.WorkId;
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var willbeUpdate = _reportService.GetById(model.Id);
                willbeUpdate.Description = model.Description;
                willbeUpdate.Detail = model.Detail;
                _reportService.Update(willbeUpdate);

               

                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> FinishedWork(int workId)
        {
            var willbeUpdate = _workService.GetById(workId);
            willbeUpdate.State = true;
            _workService.Update(willbeUpdate);

            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");

            var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);

            foreach (var admin in adminUserList)
            {
                _notificationService.Create(new Notification
                {

                    Description = $"{activeUser.Name} {activeUser.Surname} vermiş olduğunuz bir görevi tamamladı",
                    AppUserId = admin.Id
                });
            }

            return Json(null);
        }

    }
}
