using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Layer.Common.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {

        #region Crud-Operations
            public Task<T> GetByIdAsync(int id);
            public IQueryable<T> GetAllNoTracking();
            public IQueryable<T> GetAllTracking();


            public Task<bool> AddAsync(T entity);
            public Task<bool> AddRangeAsync(ICollection<T> entities);

            public Task<bool> UpdateAsync(T entity);
            public Task<bool> UpdateRangeAsync(ICollection<T> entities);

            public Task<bool> DeleteAsync(T enitiy);
            public Task<bool> DeleteRangeAsync(ICollection<T> entities);
        #endregion

        #region DB-Operations
            public Task SaveChangesAsync();

            public void Commit();

            public void RollBack();

            public IDbContextTransaction BeginTransaction(); 
        #endregion

    }
}
