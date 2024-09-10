using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<bool> AddAsync(Student student);
        public Task<List<Student>> GetAllStudents();
    }
}
