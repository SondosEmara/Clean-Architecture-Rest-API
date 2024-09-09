using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;
using University.Infrastructure.Layer.Context;

namespace University.Infrastructure.Layer.Seed
{
    public  class Seeder: ISeeder
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public Seeder(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager= roleManager;
            _userManager= userManager;
        }
        public async Task<bool> RoleSeed()
        {    
                
                var roleCount = await _roleManager.Roles.CountAsync();
                if (roleCount <= 0)
                {
                    var _roles=new List<AppRole>() { new AppRole { Name = "Admin" }, new AppRole { Name = "Student" } };
                    try
                    {
                        foreach (var role in _roles)
                        {
                           await _roleManager.CreateAsync(role);
                        }
                    }                    
                    catch (Exception)
                    {
                        return false;
                    }
            
                } 
                return true;   
        }

        public async Task<bool> StudentSeed()
        {
            var usersCount = await _userManager.Users.CountAsync();
            if (usersCount <= 0)
            {
                var _students = new List<Student>() {
                    new Student()
                    {
                        UserName = "Sondos_Student",
                        Email = "Sondos_Student@project.com",
                        PhoneNumber = "123456",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    }
                };
                try
                {
                    foreach (var stud in _students)
                    {
                        await _userManager.CreateAsync(stud, "Sondos@Test1");
                        await _userManager.AddToRoleAsync(stud, "Student");
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}
