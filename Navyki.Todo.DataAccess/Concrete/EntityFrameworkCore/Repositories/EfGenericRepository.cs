using Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Table> : IGenericDal<Table>
        where Table : class, ITable, new()
    {
        public void Create(Table T)
        {
            using var context = new TodoContext();
            context.Set<Table>().Add(T);
            context.SaveChanges();
        }

        public void Delete(Table T)
        {
            using var context = new TodoContext();
            context.Set<Table>().Remove(T);
            context.SaveChanges();
        }

        public List<Table> GetAll()
        {
            using var context = new TodoContext();
            return context.Set<Table>().ToList();
        }

        public Table GetById(int id)
        {
            using var context = new TodoContext();
            return context.Set<Table>().Find(id);

        }

        public void Update(Table T)
        {
            using var context = new TodoContext();
            context.Entry(T).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
