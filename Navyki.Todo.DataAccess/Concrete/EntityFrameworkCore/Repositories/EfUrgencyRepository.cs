using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUrgencyRepository : EfGenericRepository<Urgency>, IUrgencyDal
    {
    }
}
