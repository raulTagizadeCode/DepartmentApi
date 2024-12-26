using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManger.BL.DTOs.AppUSerDTOs;

namespace DepartmentManger.BL.Services.Abstractions
{
    public interface IAppUserService
    {
        Task<bool> RegisterAsync(AppUSerDto entityCreateDto);
        Task<string> LoginAsync(AppUserLoginDto entityLoginDto);
    }
}
