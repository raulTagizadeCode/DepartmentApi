using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DepartmentManger.BL.DTOs.AppUSerDTOs;
using DepartmentManger.BL.DTOs.DepartmentDTOs;
using DepartmentManger.DAL.Entities;

namespace DepartmentManger.BL.Profiles.AppUserProfiles
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUSerDto, AppUser>();
            
        }
    }
}
