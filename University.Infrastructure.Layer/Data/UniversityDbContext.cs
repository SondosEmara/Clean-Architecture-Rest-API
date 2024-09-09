using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using University.Domain.Layer.Enities;
using Microsoft.AspNetCore.Identity;
namespace University.Infrastructure.Layer.Data
{
    //public class IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim> : DbContext where TUser : IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim> where TRole : IdentityRole<TKey, TUserRole> where TUserLogin : IdentityUserLogin<TKey> where TUserRole : IdentityUserRole<TKey> where TUserClaim : IdentityUserClaim<TKey>
    public class UniversityDbContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        #region Configration
            public UniversityDbContext() { }
            public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options) { }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
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
