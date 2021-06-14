using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DataAccess.Interfaces
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        List<Notification> GetNotReaded(int appUserId);
        int GetNonReadedNotificationCountWithAppUserId(int id);
    }
}
