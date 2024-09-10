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
    public class StudentRepositry : GenericRepository<Student>, IStudentRepositry
    {
        public StudentRepositry(ApplicationyDbContext context) : base(context){}

        public Task<List<Student>> GetStudentsAsync()=> _enitiy.ToListAsync();
    }
}
