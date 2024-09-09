using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using University.Domain.Layer.Enities;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Reflection.Emit;
namespace University.Infrastructure.Layer.Context
{
    //public class IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim> : DbContext where TUser : IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim> where TRole : IdentityRole<TKey, TUserRole> where TUserLogin : IdentityUserLogin<TKey> where TUserRole : IdentityUserRole<TKey> where TUserClaim : IdentityUserClaim<TKey>
    public class ApplicationyDbContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        #region Configration
            public ApplicationyDbContext() { }
            public ApplicationyDbContext(DbContextOptions<ApplicationyDbContext> options) : base(options) { }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
    
                //is used in the Entity Framework Core setup to automatically apply all entity configurations (defined using IEntityTypeConfiguration<T>
                builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }

        #endregion


        #region DataSet
            public DbSet<Student> Students { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<StudentEnrollment> StudentEnrollments { get; set; }

            public DbSet<Department> Departments { get; set; }

            public DbSet<DepartmentCourse> DepartmentCourses { get; set; } 
        #endregion

    }
}
