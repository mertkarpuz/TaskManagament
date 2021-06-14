using Microsoft.EntityFrameworkCore;
using Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepostory : EfGenericRepository<Report>, IReportDal
    {
        public int GetReportCount()
        {
            using var context = new TodoContext();
            return context.Reports.Count();
        }

        public int GetReportCountWithAppUserId(int id)
        {
            using var context = new TodoContext();
            var result = context.Works.Include(x => x.Reports).Where(x => x.AppUserId == id);
            return result.SelectMany(x => x.Reports).Count();
        }

        public Report GetWithWork(int id)
        {
            using var context = new TodoContext();
            return context.Reports.Include(x => x.Work).ThenInclude(x=>x.Urgency).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
