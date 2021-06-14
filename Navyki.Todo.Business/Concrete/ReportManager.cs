using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDal _reportDal;
        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }
        public void Create(Report T)
        {
            _reportDal.Create(T);
        }

        public void Delete(Report T)
        {
            _reportDal.Delete(T);
        }

        public List<Report> GetAll()
        {
            return _reportDal.GetAll();
        }

        public Report GetById(int id)
        {
            return _reportDal.GetById(id);
        }

        public int GetReportCount()
        {
            return _reportDal.GetReportCount();
        }

        public int GetReportCountWithAppUserId(int id)
        {
            return _reportDal.GetReportCountWithAppUserId(id);
        }

        public Report GetWithWork(int id)
        {
            return _reportDal.GetWithWork(id);
        }

        public void Update(Report T)
        {
            _reportDal.Update(T);
        }
    }
}
