using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DepartmentManger.BL.DTOs.DepartmentDTOs;
using DepartmentManger.DAL.Entities;

namespace DepartmentManger.BL.Profiles.DepartmentProfiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile() 
        {
            CreateMap<DepartmentDto , Department>();
            CreateMap<DepartmentDto, Department>().ReverseMap();
        }
    }
}
