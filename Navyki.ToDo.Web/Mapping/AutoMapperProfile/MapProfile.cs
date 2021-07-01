using AutoMapper;
using Navyki.Todo.DTO.DTOs.AppUserDtos;
using Navyki.Todo.DTO.DTOs.NotificationDtos;
using Navyki.Todo.DTO.DTOs.ReportDtos;
using Navyki.Todo.DTO.DTOs.UrgencyDtos;
using Navyki.Todo.DTO.DTOs.WorkDtos;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Urgency-UrgencyDto
            CreateMap<UrgencyAddDto, Urgency>();
            CreateMap<Urgency, UrgencyAddDto>();
            CreateMap<UrgencyListDto, Urgency>();
            CreateMap<Urgency, UrgencyListDto>();
            CreateMap<UrgencyUpdateDto, Urgency>();
            CreateMap<Urgency, UrgencyUpdateDto>();
            #endregion

            #region AppUser-AppUserDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion

            #region Notification-NotificationDto
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Work-WorkDto
            CreateMap<WorkAddDto, Work>();
            CreateMap<Work, WorkAddDto>();
            CreateMap<WorkListDto, Work>();
            CreateMap<Work, WorkListDto>();
            CreateMap<WorkUpdateDto, Work>();
            CreateMap<Work, WorkUpdateDto>();
            CreateMap<WorkListAllDto, Work>();
            CreateMap<Work, WorkListAllDto>();
            #endregion

            #region Report-ReportDto

            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>(); 
            #endregion
        }
    }
}
