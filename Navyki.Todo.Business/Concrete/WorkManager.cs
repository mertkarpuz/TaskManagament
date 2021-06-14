using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Navyki.Todo.Business.Concrete
{
    public class WorkManager : IWorkService
    {
        private readonly IWorkDal _workDal;
        public WorkManager(IWorkDal workDal)
        {
            _workDal = workDal;
        }
        public void Create(Work T)
        {
            _workDal.Create(T);
        }

        public void Delete(Work T)
        {
            _workDal.Delete(T);
        }

        public List<Work> GetAll()
        {
            return _workDal.GetAll();
        }

        public List<Work> GetAllWithTables()
        {
            return _workDal.GetAllWithTables();
        }

        public List<Work> GetAllWithTables(Expression<Func<Work, bool>> filter)
        {
            return _workDal.GetAllWithTables(filter);
        }

        public Work GetById(int id)
        {
            return _workDal.GetById(id);
        }

        public int GetCompletedWorks()
        {
            return _workDal.GetCompletedWorks();
        }

        public Work GetUrgencyWithId(int id)
        {
            return _workDal.GetUrgencyWithId(id);
        }

        public List<Work> GetWAppUserId(int appUserId)
        {
            return _workDal.GetWAppUserId(appUserId);
        }

        public List<Work> GetWillAllTablesUnComp(out int totalPage, int userId, int activePage)
        {
            return _workDal.GetWillAllTablesUnComp(out totalPage, userId, activePage);
        }

        public int GetWillBeAssignWorkCountWith()
        {
            return _workDal.GetWillBeAssignWorkCountWith();
        }

        public List<Work> GetWithUrgencyUnComp()
        {
            return _workDal.GetWithUrgencyUnComp();
        }

        public int GetWorkCountCompletedWithAppUserId(int id)
        {
            return _workDal.GetWorkCountCompletedWithAppUserId(id);
        }

        public int GetWorkCountNonCompletedWithAppUserId(int id)
        {
            return _workDal.GetWorkCountNonCompletedWithAppUserId(id);
        }

        public Work GetWReportsWId(int id)
        {
            return _workDal.GetWReportsWId(id);
        }

        public void Update(Work T)
        {
            _workDal.Update(T);
        }
    }
}
