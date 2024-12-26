using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DepartmentManger.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.PowerBI.Api.Models;
using AppUser = DepartmentManger.DAL.Entities.AppUser;

namespace DepartmentManger.DAL.Contexts
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; } 
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
} 
