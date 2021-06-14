using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.Interfaces
{
    public interface IReportService : IGenericService<Report>
    {
        Report GetWithWork(int id);
        int GetReportCountWithAppUserId(int id);
        int GetReportCount();
    }
}
