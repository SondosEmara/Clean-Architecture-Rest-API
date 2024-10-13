using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;
using University.Application.Layer.Features.Students.Commands.Models;
using University.Application.Layer.Features.User.Commands.Models;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Features.User.Commands.Handlers
{
    public class AddUserCommandHandle : IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public AddUserCommandHandle(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user =await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
               return  ResponseHandler.Failed("The Email Already Exist");
            }
            user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
               return ResponseHandler.Failed("The Username Already Exist");
            }
            var result = _mapper.Map<AppUser>(request);

            var createdUserRes = await _userManager.CreateAsync(result);
            if (!createdUserRes.Succeeded)
            {
                ResponseHandler.Failed(createdUserRes?.Errors?.FirstOrDefault()?.Description);
            }
            //_userManager.AddToRoleAsync();
            return ResponseHandler.Success("Created....!");

        }
    }
}
