using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Domain.Layer.Enities
{
    public class AppUserRole:IdentityUserRole<int>
    {
        //we need to add the relationship 1-M With the 
        //in the DB --> Create Table Have the (userId,roleId).
        
        public AppUser User { get; set; } = null!;
        public AppRole Role { get; set; } = null!;
    }
}
