using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Navyki.Todo.Business.Interfaces
{
    public interface IWorkService: IGenericService<Work>
    {
        List<Work> GetWithUrgencyUnComp();
        List<Work> GetAllWithTables();
        List<Work> GetWAppUserId(int appUserId);
        int GetWorkCountNonCompletedWithAppUserId(int id);
        Work GetUrgencyWithId(int id);
        Work GetWReportsWId(int id);
        List<Work> GetWillAllTablesUnComp(out int totalPage, int userId, int activePage=1);
        List<Work> GetAllWithTables(Expression<Func<Work, bool>> filter);
        int GetWorkCountCompletedWithAppUserId(int id);
        int GetWillBeAssignWorkCountWith();
        int GetCompletedWorks();
    }
}
