using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetNotAdmin();
        List<AppUser> GetNotAdmin(out int totalPage, string SearchKey, int ActivePage = 1);
        List<DualHelper> MostWorkComplatedMembers();
        List<DualHelper> MostWorkAssignedMembers();
    }
}
