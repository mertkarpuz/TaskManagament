using Microsoft.EntityFrameworkCore;
using Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Navyki.Todo.DataAccess.Interfaces;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navyki.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository :  IAppUserDal
    {
        public List<AppUser> GetNotAdmin()
        {
            using var context = new TodoContext();
            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {

                user = resultUser,
                userRole = resultUserRole

            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
            (resultTable, resultRole) => new
            {
                resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }
            ).Where(x => x.roles.Name == "Member").Select(x => new AppUser
            {

                Id = x.user.Id,
                Name = x.user.Name,
                Surname = x.user.Surname,
                Picture = x.user.Picture,
                Email = x.user.Email,
                UserName = x.user.UserName


            }).ToList();
        }

        public List<AppUser> GetNotAdmin(out int totalPage, string searchKey,int activePage=1)
        {
            using var context = new TodoContext();
            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {

                user = resultUser,
                userRole = resultUserRole

            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
            (resultTable, resultRole) => new
            {
                resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }
            ).Where(x => x.roles.Name == "Member").Select(x => new AppUser
            {

                Id = x.user.Id,
                Name = x.user.Name,
                Surname = x.user.Surname,
                Picture = x.user.Picture,
                Email = x.user.Email,
                UserName = x.user.UserName


            });

            totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                result = result.Where(I => I.Name.ToLower().Contains(searchKey.ToLower()) || I.Surname.ToLower().Contains(searchKey.ToLower()));
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);
            }

            result = result.Skip((activePage - 1) * 3).Take(3);

            return result.ToList();
        }

        public List<DualHelper> MostWorkComplatedMembers()
        {
            using var context = new TodoContext();
            return  context.Works.Include(x => x.AppUser).Where(x => x.State).GroupBy(x => x.AppUser.UserName).OrderByDescending(x => x.Count()).Take(5).Select(x => new
            DualHelper {
                Name = x.Key,
                WorkCount =x.Count()
            }).ToList();
        }
        public List<DualHelper> MostWorkAssignedMembers()
        {
            using var context = new TodoContext();
            return context.Works.Include(x => x.AppUser).Where(x => !x.State && x.AppUserId != null).GroupBy(x => x.AppUser.UserName).OrderByDescending(x => x.Count()).Take(5).Select(x => new
            DualHelper
            {
                Name = x.Key,
                WorkCount = x.Count()
            }).ToList();
        }
    }
}

