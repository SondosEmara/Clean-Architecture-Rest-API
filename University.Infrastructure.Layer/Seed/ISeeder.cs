using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;

namespace University.Infrastructure.Layer.Seed
{
    internal interface ISeeder
    {
        public Task<bool> RoleSeed();
        public Task<bool> StudentSeed();

    }
}
