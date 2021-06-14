using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetNotAdmin();
        List<AppUser> GetNotAdmin(out int totalPage,string SearchKey, int ActivePage = 1);
        List<DualHelper> MostWorkAssignedMembers();
        List<DualHelper> MostWorkComplatedMembers();
    }
}
