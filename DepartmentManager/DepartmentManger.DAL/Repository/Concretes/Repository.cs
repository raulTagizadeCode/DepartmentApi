using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManger.DAL.Contexts;
using DepartmentManger.DAL.Entities;
using DepartmentManger.DAL.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DepartmentManger.DAL.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        public readonly AppDBContext _aContext;

        public Repository(AppDBContext aContext)
        {
            _aContext = aContext;
        }

        public DbSet<T> Table => _aContext.Set<T>();

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
             int rows = await _aContext.SaveChangesAsync();
            if (rows == 0) 
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<T> Delete(int id)
        {
            T? res = await GetByIdAsync(id);
            _aContext.Remove(res);
            await _aContext.SaveChangesAsync();
            return res;
        }

        public async Task<List<T>> GetAllAsync()
        {
           List<T> res =  await Table.ToListAsync();
            return res;
        }

        public async Task<T> GetByIdAsync(int id)
        {
          var res = await Table.FindAsync(id);
            if (res == null)
            {
                throw new Exception($"Entity not fount id={id}");
            }
            return res;
        }

        

       

        public async Task UpdateAsync(T entity)
        {
            var res = await Table.AsNoTracking().SingleOrDefaultAsync(t=>t.Id==entity.Id);
            if(res is not null)
            {
                Table.Update(entity);
            }
            else
            {
                throw new Exception("Entity not found");
            }
            await _aContext.SaveChangesAsync();
        }
    }
}
