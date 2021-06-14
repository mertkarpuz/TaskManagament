using Navyki.Todo.Business.Interfaces;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _userDal;
        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<AppUser> GetNotAdmin()
        {
            return _userDal.GetNotAdmin();
        }

        public List<AppUser> GetNotAdmin(out int totalPage, string SearchKey, int ActivePage)
        {
            return _userDal.GetNotAdmin(out totalPage, SearchKey, ActivePage);
        }

        public List<DualHelper> MostWorkAssignedMembers()
        {
            return _userDal.MostWorkAssignedMembers();
        }

        public List<DualHelper> MostWorkComplatedMembers()
        {
            return _userDal.MostWorkComplatedMembers();
        }
    }
}
