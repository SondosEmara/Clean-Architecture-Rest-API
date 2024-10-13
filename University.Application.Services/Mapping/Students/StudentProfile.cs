using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Features.Students.Commands.Models;
using University.Domain.Layer.Enities;
using University.Domain.Layer.Enums;
using University.Application.Layer.Features.Students.Queries.Results;
using University.Application.Layer.Features.Authentication.Commands.Models;

namespace University.Application.Layer.Mapping.Students
{
    public class StudentProfile:Profile
    {
        public StudentProfile() 
        {
            //Map the Student To the GETListResponse <Source,Destionation>
            CreateMap<Student, GetStudentListResponse>()
                      .ForMember(dest=>dest.StudLevel,opt=>opt.MapFrom(source=>source.Level.ToString()));
            CreateMap<Student, GetSingleStudentResponse>();
            CreateMap<AddStudentCommand,Student>();
            CreateMap<EditStudentCommand, Student>();
            //CreateMap<AddUserCommand,AppUser>();
            //ForMember(dest=>dest.StudentLevel,opt=>opt.MapFrom(source=>source.Level));
        }
    }
}
