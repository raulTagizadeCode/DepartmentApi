using AutoMapper;
using DepartmentManger.BL.DTOs.DepartmentDTOs;
using DepartmentManger.DAL.Entities;
using DepartmentManger.DAL.Repository.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly IRepository<Department> _repository;
        public readonly IMapper _mapper;
        public DepartmentController(IRepository<Department> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<List<Department>> GetAll()
        {
          List<Department> res =  await _repository.GetAllAsync();
            return res;
        }
        [HttpGet("GetById")]
        public async Task<Department> GetByID([FromForm]int id) 
        {
           Department res = await _repository.GetByIdAsync(id);
            return res;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] DepartmentDto departmentDto)
        {
            Department department = _mapper.Map<Department>(departmentDto); 
            {
                
                department.CreateAtt=DateTime.Now;
            };
            await _repository.CreateAsync(department);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm]DepartmentDto departmentDto, int id)
            {
            Department department = _mapper.Map<Department>(departmentDto);
            {
                department.Id = id;
                department.CreateAtt = DateTime.Now;
            };
            await _repository.UpdateAsync(department);
            return Ok();
        }
    }
}
