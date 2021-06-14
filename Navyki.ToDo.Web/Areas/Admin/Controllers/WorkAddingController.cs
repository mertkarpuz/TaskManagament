using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.Entities.Concrete;
using Navyki.ToDo.Web.Areas.Admin.Models;

namespace Navyki.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class WorkAddingController : Controller
    {
        public readonly IAppUserService _appUserService;
        public readonly IWorkService _workService;
        public readonly UserManager<AppUser> _userManager;
        public readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        public WorkAddingController(IAppUserService appUserService, IWorkService workService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService)
        {
            _appUserService = appUserService;
            _workService = workService;
            _userManager = userManager;
            _fileService = fileService;
            _notificationService = notificationService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "workadding";
            List<Work> works = _workService.GetAllWithTables();
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


        public IActionResult AssignMember(int id, string s, int page = 1)
        {
            TempData["Active"] = "workadding";
            ViewBag.activePage = page;
            //ViewBag.TotalPage = (int)Math.Ceiling((double)_appUserService.GetNotAdmin().Count / 3);
            int totalPage;
            var members = _appUserService.GetNotAdmin(out totalPage, s, page);

            ViewBag.TotalPage = totalPage;
            ViewBag.Searched = s;

            List<AppUserListVM> AppUserListmodel = new List<AppUserListVM>();
            foreach (var item in members)
            {
                AppUserListVM model = new AppUserListVM();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Surname = item.Surname;
                model.Email = item.Email;
                model.Picture = item.Picture;
                AppUserListmodel.Add(model);
            }
            ViewBag.Members = AppUserListmodel;
            var urgency = _workService.GetUrgencyWithId(id);
            WorkListVM Workmodel = new WorkListVM();
            Workmodel.Id = urgency.Id;
            Workmodel.Name = urgency.Name;
            Workmodel.Description = urgency.Description;
            Workmodel.Urgency = urgency.Urgency;
            Workmodel.CreatedTime = urgency.CreatedTime;
            return View(Workmodel);
        }


        [HttpPost]
        public IActionResult AssignMember(MemberWorkAssignVM model)
        {
            TempData["Active"] = "workadding";
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
            TempData["Active"] = "workadding";
            var work = _workService.GetWReportsWId(id);
            WorkListAllVM model = new WorkListAllVM();
            model.Id = work.Id;
            model.Reports = work.Reports;
            model.Name = work.Name;
            model.Description = work.Description;
            model.AppUser = work.AppUser;
            return View(model);
        }






        public IActionResult WorkAssignMember(MemberWorkAssignVM model)
        {
            TempData["Active"] = "workadding";
            var returnedUser = _userManager.Users.FirstOrDefault(x => x.Id == model.MemberId);
            var returnedWork = _workService.GetUrgencyWithId(model.WorkId);

            AppUserListVM userModel = new AppUserListVM();
            userModel.Id = returnedUser.Id;
            userModel.Name = returnedUser.Name;
            userModel.Picture = returnedUser.Picture;
            userModel.Surname = returnedUser.Surname;
            userModel.Email = returnedUser.Email;

            WorkListVM workModel = new WorkListVM();
            workModel.Id = returnedWork.Id;
            workModel.Description = returnedWork.Description;
            workModel.Urgency = returnedWork.Urgency;
            workModel.Name = returnedWork.Name;

            MemberWorkAssignListVM memberAssignWorkModel = new MemberWorkAssignListVM();

            memberAssignWorkModel.AppUser = userModel;
            memberAssignWorkModel.Work = workModel;


            return View(memberAssignWorkModel);
        }

        public IActionResult GetExcel(int id)
        {
            return File(_fileService.TransferExcel(_workService.GetWReportsWId(id).Reports), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult GetPdf(int id)
        {
            var path = _fileService.TransferPdf(_workService.GetWReportsWId(id).Reports);
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}
