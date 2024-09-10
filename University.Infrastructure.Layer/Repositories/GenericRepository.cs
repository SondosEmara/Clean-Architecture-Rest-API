using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using University.Application.Layer.Common.Interfaces;
using University.Domain.Layer.Enities;
using University.Infrastructure.Layer.Context;

namespace University.Infrastructure.Layer.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationyDbContext _context;
        public DbSet<T> _enitiy=> _context.Set<T>();
        public GenericRepository(ApplicationyDbContext context)=>_context = context;
        
        public virtual async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _enitiy.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false ;
            }
        }

        public async Task<bool> AddRangeAsync(ICollection<T> entities)
        {
            try
            {
                await _enitiy.AddRangeAsync(entities);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception) 
            {
               return false;
            }
        }

        public async Task<bool> DeleteAsync(T enitiy)
        {
            try
            {
                _enitiy.Remove(enitiy);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> DeleteRangeAsync(ICollection<T> entities)
        {
            try
            {
                _context.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }
        }

        public IQueryable<T> GetAllNoTracking()
        { 
            try
            {
                return _enitiy.AsNoTracking().AsQueryable();

            }
            catch (Exception)
            {
                return Enumerable.Empty<T>().AsQueryable();
            }
        }

        public IQueryable<T> GetAllTracking()
        {
            try
            {
                return _enitiy.AsQueryable();
            }
            catch (Exception) 
            {
                return Enumerable.Empty<T>().AsQueryable(); 
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _enitiy.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false ;
            }
        }

        public async Task<bool> UpdateRangeAsync(ICollection<T> entities)
        {
            try
            {
                _enitiy.UpdateRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return (await _enitiy.FindAsync(id))??Activator.CreateInstance<T>(); ;
            }
            catch
            {
                return Activator.CreateInstance<T>();
            }
        }
      
        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public IDbContextTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
