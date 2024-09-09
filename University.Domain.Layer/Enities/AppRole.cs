using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Domain.Layer.Enities
{
    //This include all roles in the app
    //table in DB --> (RoleId,RoleName)
    //                (1,Admin)
    public class AppRole:IdentityRole<int>
    {
        //that mean the role have many users.
        public List<AppUserRole> AppUsersRoles { get; } = new();
    }
}
