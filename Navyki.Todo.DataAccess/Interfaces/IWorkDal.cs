using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Navyki.Todo.DataAccess.Interfaces
{
    public interface IWorkDal : IGenericDal<Work>
    {
        List<Work> GetWithUrgencyUnComp();
        List<Work> GetAllWithTables();
        List<Work> GetAllWithTables(Expression<Func<Work,bool>> filter);
        List<Work> GetWillAllTablesUnComp(out int totalPage, int userId, int activePage);
        List<Work> GetWAppUserId(int appUserId);
        Work GetUrgencyWithId(int id);
        Work GetWReportsWId(int id);
        int GetWorkCountCompletedWithAppUserId(int id);
        int GetWorkCountNonCompletedWithAppUserId(int id);
        int GetWillBeAssignWorkCountWith();
        int GetCompletedWorks();
      
    }
}
