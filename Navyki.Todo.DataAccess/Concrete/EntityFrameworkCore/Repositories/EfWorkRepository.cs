using Microsoft.EntityFrameworkCore;
using Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : EfGenericRepository<Work>, IWorkDal
    {
        public List<Work> GetAllWithTables()
        {
            using var context = new TodoContext();
            return context.Works.Include(x => x.Urgency).Include(x => x.Reports).Include(x => x.AppUser).Where(x => !x.State).OrderByDescending(x => x.CreatedTime).ToList();
        }

        public Work GetUrgencyWithId(int id)
        {
            using var context = new TodoContext();
            return context.Works.Include(x => x.Urgency).FirstOrDefault(x => !x.State && x.Id == id);
        }


        public Work GetWReportsWId(int id)
        {
            using var context = new TodoContext();
            return context.Works.Include(x => x.Reports).Include(x=>x.AppUser).Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Work> GetWAppUserId(int appUserId)
        {
            using var context = new TodoContext();
            return context.Works.Where(x => x.AppUserId == appUserId).ToList();
        }

        public List<Work> GetWithUrgencyUnComp() /// eager loading
        {
            using var context = new TodoContext();
            return context.Works.Include(x => x.Urgency).Where(x => !x.State).OrderByDescending(x => x.CreatedTime).ToList();
        }

        public List<Work> GetAllWithTables(Expression<Func<Work, bool>> filter)
        {
            using var context = new TodoContext();
            return context.Works.Include(x => x.Urgency).Include(x => x.Reports).Include(x => x.AppUser).Where(filter).OrderByDescending(x => x.CreatedTime).ToList();
        }

        public List<Work> GetWillAllTablesUnComp(out int totalPage, int userId, int activePage=1)
        {
            using var context = new TodoContext();
            var returnValue = context.Works.Include(x => x.Urgency).Include(x => x.Reports).Include(x => x.AppUser).Where(x => x.AppUserId == userId && x.State).OrderByDescending(x => x.CreatedTime);

            totalPage = (int)Math.Ceiling((double)returnValue.Count() / 3);

            return returnValue.Skip((activePage - 1) * 3).Take(3).ToList();
        }

        public int GetWorkCountCompletedWithAppUserId(int id)
        {
            using var context = new TodoContext();
            return context.Works.Count(x => x.AppUserId == id && x.State);
        }

        public int GetWorkCountNonCompletedWithAppUserId(int id)
        {
            using var context = new TodoContext();
            return context.Works.Count(x => x.AppUserId == id && !x.State);
        }

        public int GetWillBeAssignWorkCountWith()
        {
            using var context = new TodoContext();
            return context.Works.Count(x => x.AppUserId == null && !x.State);
        }

        public int GetCompletedWorks()
        {
            using var context = new TodoContext();
            return context.Works.Count(x=>x.State);
        }
    }
}
