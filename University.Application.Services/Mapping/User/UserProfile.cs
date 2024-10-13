using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Features.Students.Commands.Models;
using University.Application.Layer.Features.Students.Queries.Results;
using University.Application.Layer.Features.Authentication.Commands.Models;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Mapping.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserCommand,AppUser>();
        }
    }
}
