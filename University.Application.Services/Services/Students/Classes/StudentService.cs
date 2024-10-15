using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Interfaces;
using University.Application.Layer.Helpers;
using University.Application.Layer.Services.Students.DTO;
using University.Application.Layer.Services.Students.Interface;
using University.Application.Layer.Services.Students.Result;
using University.Application.Layer.Wrappers;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Services.Students.Classes
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositry _studentRepositry;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepositry studentRepositry,IMapper mapper)
        {
            _studentRepositry = studentRepositry;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(AddStudentDto newStudent)
        {
            var targetStud = _mapper.Map<Student>(newStudent);
            var ifExist = await _studentRepositry.GetAllNoTracking().AnyAsync(stud => stud.Email == targetStud.Email);
            if (ifExist) return false;
            await _studentRepositry.AddAsync(targetStud);
            return true;
        }

        public async Task<bool> EditAsync(EditStudentDto editStudnt)
        {
            var student = await _studentRepositry.GetByIdAsync(editStudnt.Id);
            if (student == null) return false;
            var mappedStudent = _mapper.Map<Student>(editStudnt);
            return await _studentRepositry.UpdateAsync(student);
        }


        public async Task<List<GetStudentListResponse>> GetAllStudents()
        {
            var studentList = await _studentRepositry.GetStudentsAsync();
            var reseult = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return reseult;
        }

        public async Task<GetSingleStudentResponse> GetStudentById(int id)
        {
            var targetStudent=await _studentRepositry.GetByIdAsync(id);
            var reseult = _mapper.Map<GetSingleStudentResponse>(targetStudent);
            return reseult;
        }

        public IQueryable<Student> GetStudentFiltered(StudentFilteredDto _paramaters)
        {
            var students = _studentRepositry.GetAllNoTracking();
            if (!string.IsNullOrEmpty(_paramaters.SerachTerm)) students = students.Where(stud => stud.UserName == _paramaters.SerachTerm);

            if (_paramaters.OrderBy != null)
            {
                switch (_paramaters.OrderBy)
                {
                    case OrderStudentEnum.studID:
                        students = students.OrderByDescending(stud => stud.Id);
                        break;
                    case OrderStudentEnum.studName:
                        students = students.OrderByDescending(stud => stud.UserName);
                        break;
                    _: throw new NotImplementedException();
                }
            }
            return students;
        }

        public async Task<PagniationResult<GetStudentListResponse>> GetStudentPagniaedList(StudentPagniaedListDto request)
        {
            //Create Func Input is Student and Output is the GetStudentPagniaedListQuery
            Expression<Func<Student, GetStudentListResponse>> expression = (studentInput) => new GetStudentListResponse { Id = studentInput.Id, UserName = studentInput.UserName, Email = studentInput.Email, PhoneNumber = studentInput.PhoneNumber, StudLevel = studentInput.Level.ToString() };
            var filteredResult = GetStudentFiltered(new StudentFilteredDto { SerachTerm = request.Search, OrderBy = request.OrderBy });
            if (filteredResult == null) return new PagniationResult<GetStudentListResponse>();
            return await filteredResult.Select(expression).ToPaginaedListAsync(request.PageSize, request.PageNumber);
        }

        public Task<PagniationResult<GetStudentListResponse>> GetStudentPagniaedList()
        {
            throw new NotImplementedException();
        }
    }
}
