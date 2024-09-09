using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace University.Domain.Layer.Enities
{
    //In the user exist all common properties of the all users in the system (Admin/Student/Instructor).
    public class AppUser : IdentityUser<int>
    {
        public Gender Gender { get; set; }
        public List<AppUserRole> AppUserRoles { get; } = new();
    }
}
