using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManger.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DepartmentManger.DAL.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(d=> d.Department)
                 .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);
            
            builder.Property(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(15);
            builder.Property(e => e.SurName).HasMaxLength(20);
            
        }
    }
}
