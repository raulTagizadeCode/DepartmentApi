using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManger.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepartmentManger.DAL.Repository.Abstractions
{
    public interface IRepository<T> where T : BaseEntity, new() 
    {
        DbSet<T> Table { get; }
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
       Task CreateAsync(T entity);
        Task<T> Delete(int id);
        
        Task UpdateAsync(T entity);
    }

   
}
