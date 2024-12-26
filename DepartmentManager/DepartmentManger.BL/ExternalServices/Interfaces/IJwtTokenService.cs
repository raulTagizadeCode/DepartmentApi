using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManger.DAL.Entities;

namespace DepartmentManger.BL.ExternalServices.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(AppUser appUser);
    }
}
