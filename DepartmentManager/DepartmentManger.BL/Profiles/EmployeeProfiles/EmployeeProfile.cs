using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DepartmentManger.BL.DTOs.EmployeeDTOs;
using DepartmentManger.DAL.Entities;

namespace DepartmentManger.BL.Profiles.EmployeeProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
        }
    }
}
