using AutoMapper;
using DepartmentManger.BL.DTOs.DepartmentDTOs;
using DepartmentManger.BL.DTOs.EmployeeDTOs;
using DepartmentManger.DAL.Entities;
using DepartmentManger.DAL.Repository.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IRepository<Employee> _repository;
        public readonly IMapper _mapper;
        public EmployeeController(IRepository<Employee> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<List<Employee>> GetAll()
        {
            List<Employee> res = await _repository.GetAllAsync();
            return res;
        }
        [HttpGet("GetById")]
        public async Task<Employee> GetByID([FromForm] int id)
        {
            Employee res = await _repository.GetByIdAsync(id);
            return res;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            {
                
                employee.CreateAtt=DateTime.Now;
            };
            await _repository.CreateAsync(employee);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] EmployeeDto employeeDto, int id)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            {
                employee.Id = id;
                employee.UpdateAtt = DateTime.Now;
            };
            await _repository.UpdateAsync(employee);
            return Ok();
        }
    }
}
