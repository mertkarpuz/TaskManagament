using Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public int GetNonReadedNotificationCountWithAppUserId(int id)
        {
            using var context = new TodoContext();
            return context.Notifications.Count(x => x.AppUserId == id && !x.State);
        }

        public List<Notification> GetNotReaded(int appUserId)
        {
            using var context = new TodoContext();
            return context.Notifications.Where(x => x.AppUserId == appUserId && x.State == false).ToList();
        }
    }
}
