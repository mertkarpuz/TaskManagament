using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Create(Notification T)
        {
            _notificationDal.Create(T);
        }

        public void Delete(Notification T)
        {
            _notificationDal.Delete(T);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public int GetNonReadedNotificationCountWithAppUserId(int id)
        {
            return _notificationDal.GetNonReadedNotificationCountWithAppUserId(id);
        }

        public List<Notification> GetNotReaded(int appUserId)
        {
            return _notificationDal.GetNotReaded(appUserId);
        }

        public void Update(Notification T)
        {
            _notificationDal.Update(T);
        }
    }
}
