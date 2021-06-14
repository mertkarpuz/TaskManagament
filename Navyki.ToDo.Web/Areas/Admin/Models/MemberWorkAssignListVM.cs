using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web.Areas.Admin.Models
{
    public class MemberWorkAssignListVM
    {
        public AppUserListVM AppUser{ get; set; }
        public WorkListVM Work { get; set; }
    }
}
