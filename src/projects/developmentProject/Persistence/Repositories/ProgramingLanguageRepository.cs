using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public class ProgramingLanguageRepository : EfRepositoryBase<ProgramingLanguage, BaseDbContext>, IProgramingLanguageRepository
    {
        public ProgramingLanguageRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
