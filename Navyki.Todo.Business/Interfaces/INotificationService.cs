using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetNotReaded(int appUserId);
        int GetNonReadedNotificationCountWithAppUserId(int id);
    }
}
