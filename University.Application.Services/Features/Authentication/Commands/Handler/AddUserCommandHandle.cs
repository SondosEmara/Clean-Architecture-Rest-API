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
using University.Application.Layer.Features.Authentication.Commands.Models;
using University.Domain.Layer.Enities;
using Microsoft.AspNetCore.Http;
using University.Application.Layer.Services.Interfaces;
using University.Application.Layer.Common.Interfaces;

namespace University.Application.Layer.Features.Authentication.Commands.Handler
{
    public class AddUserCommandHandle : IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmaillService _emaillService;
        private readonly IGenericRepositoryAsync<Student> _genericRepo;
        public AddUserCommandHandle(UserManager<AppUser> userManager, IMapper mapper,IHttpContextAccessor httpContextAccessor, IEmaillService emaillService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _emaillService = emaillService;
        }
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
                   //Create Transcation Because if exist problem need To Roolback
                   var transaction =  _genericRepo.BeginTransaction();


                    var user = await _userManager.FindByEmailAsync(request.Email);
                    if (user != null)
                    {
                        return ResponseHandler.Failed("The Email Already Exist");
                    }
                    user = await _userManager.FindByNameAsync(request.UserName);
                    if (user != null)
                    {
                        return ResponseHandler.Failed("The Username Already Exist");
                    }
                    var result = _mapper.Map<AppUser>(request);

                    var createdUserRes = await _userManager.CreateAsync(result, request.Password);
                    if (!createdUserRes.Succeeded)
                    {
                        return ResponseHandler.Failed(createdUserRes?.Errors?.FirstOrDefault()?.Description??" not   ");
                    }
                    //_userManager.AddToRoleAsync();
                    //Can send Confirm Email



                    //Here Send Email Confirmed
                    var code =_userManager.GenerateEmailConfirmationTokenAsync(result);
                    var requestAccessor =_httpContextAccessor.HttpContext.Request;

                    //Create Api With Authentication Not Send User Id Send Only Codee
                    //in the confirmed api make emailconfirmed true;
   
                    var returnURL =requestAccessor.Scheme+"://"+requestAccessor.Host+$"Api/V1/Authentication/ConifrmatoinEmail?userId={result.Id}&code={code}";
                    Console.WriteLine($"CODE: {code}");
                    Console.WriteLine($"Return URL: {returnURL}");
                    await _emaillService.SendEmailAsync(result.Email,returnURL);

                    return ResponseHandler.Success("Created....!");

        }
    }
}
