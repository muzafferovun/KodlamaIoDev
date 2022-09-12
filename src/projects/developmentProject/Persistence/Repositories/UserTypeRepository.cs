using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserTypeRepository : EfRepositoryBase<UserType, BaseDbContext>, IUserTypeRepository
    {
        public UserTypeRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
