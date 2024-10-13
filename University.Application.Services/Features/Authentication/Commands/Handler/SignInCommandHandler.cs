using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Bases;
using University.Application.Layer.Features.Authentication.Commands.Models;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Features.Authentication.Commands.Handler
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, Response<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        public SignInCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var failedResult= ResponseHandler.Failed("NotExtist.....!");
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return failedResult;
            var signInResult= await _userManager.CheckPasswordAsync(user,request.PassWord);
            if (signInResult==false) return failedResult;

            //Genertae Token HERE 

            return ResponseHandler.Success("Exist Success.....!"); ;
        }
    }
}
