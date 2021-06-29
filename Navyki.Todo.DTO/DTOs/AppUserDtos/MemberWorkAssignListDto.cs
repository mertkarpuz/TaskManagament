using Navyki.Todo.DTO.DTOs.WorkDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DTO.DTOs.AppUserDtos
{
    public class MemberWorkAssignListDto
    {
        public AppUserListDto AppUser { get; set; }
        public WorkListDto Work { get; set; }
    }
}
