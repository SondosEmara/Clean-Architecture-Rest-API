using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Interfaces;
using University.Application.Layer.Services.Interfaces;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Services.Classes
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositry _studentRepositry;
        public StudentService(IStudentRepositry studentRepositry)
        {
            _studentRepositry = studentRepositry;
        }

        public async Task<bool> AddAsync(Student newStudent)
        {
            var ifExist=await _studentRepositry.GetAllNoTracking().AnyAsync(stud=>stud.Email==newStudent.Email);
            if(ifExist) return false;
            await _studentRepositry.AddAsync(newStudent);
            return true; 
        }

        public async Task<List<Student>> GetAllStudents() => await _studentRepositry.GetStudentsAsync();

        public async Task<Student> GetStudentById(int id)=> await _studentRepositry.GetByIdAsync(id);
        
    }
}
