using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Interfaces;
using University.Domain.Layer.Enities;
using University.Infrastructure.Layer.Context;

namespace University.Infrastructure.Layer.Repositories
{
    public class DepartmentRepositry:GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepositry(ApplicationyDbContext dbContext) : base(dbContext) { }
    }
}
