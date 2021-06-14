using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly IUrgencyDal _urgencyDal;
        public UrgencyManager(IUrgencyDal urgencyDal)
        {
            _urgencyDal = urgencyDal;
        }

        public void Create(Urgency T)
        {
            _urgencyDal.Create(T);
        }

        public void Delete(Urgency T)
        {
            _urgencyDal.Delete(T);
        }

        public List<Urgency> GetAll()
        {
           return _urgencyDal.GetAll();
        }

        public Urgency GetById(int id)
        {
            return _urgencyDal.GetById(id);
        }

        public void Update(Urgency T)
        {
            _urgencyDal.Update(T);
        }
    }
}
