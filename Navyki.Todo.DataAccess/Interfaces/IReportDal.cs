using Navyki.Todo.Entities.Concrete;


namespace Navyki.Todo.DataAccess.Interfaces
{
    public interface IReportDal : IGenericDal<Report>
    {
        Report GetWithWork(int id);
        int GetReportCountWithAppUserId(int id);
        int GetReportCount();
    }
}
