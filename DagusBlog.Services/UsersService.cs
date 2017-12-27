using DagusBlog.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DagusBlog.Models;
using DagusBlog.Services;
using DagusBlog.Data;

namespace DagusBlog.Services
{
    public class UsersService : BaseService<ApplicationUser>, IUsersService
    {
        public UsersService(IBlogSystemData data) : base(data)
        {
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.Data.Users.All();
        }
    }
}
