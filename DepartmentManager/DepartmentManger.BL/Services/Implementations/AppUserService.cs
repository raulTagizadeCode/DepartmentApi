using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DepartmentManger.BL.DTOs.AppUSerDTOs;
using DepartmentManger.BL.ExternalServices.Interfaces;
using DepartmentManger.BL.Services.Abstractions;
using DepartmentManger.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DepartmentManger.BL.Services.Implementations
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;

        public AppUserService(UserManager<AppUser> userManager, IMapper mapper, IJwtTokenService jwtTokenService )
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> LoginAsync(AppUserLoginDto entityLoginDto)
        {
            AppUser existingUser = await _userManager.FindByNameAsync(entityLoginDto.UserName);
            if (existingUser == null) { throw new Exception(); }
            bool result = await _userManager.CheckPasswordAsync(existingUser, entityLoginDto.Password);
            if (!result) { throw new Exception("Username or password is wrong"); }
            string token = _jwtTokenService.GenerateToken(existingUser);
            return token;
        }

        public async Task<bool> RegisterAsync(AppUSerDto entityCreateDto)
        {
            AppUser user = _mapper.Map<AppUser>(entityCreateDto);
            var result = await _userManager.CreateAsync(user, entityCreateDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Could not create user");
            }
            return true;

        }
    }
}
