using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;
using University.Presentaion.Contracts.Features.Students.Queries.Results;

namespace University.Presentaion.Contracts.Mapping.Students
{
    public class StudentProfile:Profile
    {
        public StudentProfile() 
        {
            //Map the Student To the GETListResponse <Source,Destionation>
            CreateMap<Student, GetStudentListResponse>()
                      .ForMember(dest=>dest.StudLevel,opt=>opt.MapFrom(source=>source.Level.ToString()));
        }
    }
}
