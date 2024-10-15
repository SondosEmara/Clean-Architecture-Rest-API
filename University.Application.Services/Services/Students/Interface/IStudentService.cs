using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Services.Students.DTO;
using University.Application.Layer.Services.Students.Result;
using University.Application.Layer.Wrappers;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Services.Students.Interface
{
    public interface IStudentService
    {
        public Task<bool> AddAsync(AddStudentDto newStudent);
        public Task<bool> EditAsync(EditStudentDto student);
        public Task<GetSingleStudentResponse> GetStudentById(int id);
        public Task<List<GetStudentListResponse>> GetAllStudents();
        public Task<PagniationResult<GetStudentListResponse>> GetStudentPagniaedList(StudentPagniaedListDto studentFilter);
        public IQueryable<Student> GetStudentFiltered(StudentFilteredDto paramaters);
    }
}
