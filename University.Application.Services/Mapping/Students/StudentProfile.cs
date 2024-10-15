using AutoMapper;
using University.Application.Layer.Services.Students.DTO;
using University.Application.Layer.Services.Students.Result;
using University.Domain.Layer.Enities;


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
            CreateMap<AddStudentDto,Student>();
            CreateMap<EditStudentDto, Student>();
            //ForMember(dest=>dest.StudentLevel,opt=>opt.MapFrom(source=>source.Level));
        }
    }
}
