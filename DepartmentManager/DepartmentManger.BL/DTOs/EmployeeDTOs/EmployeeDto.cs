using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManger.BL.DTOs.DepartmentDTOs;
using DepartmentManger.DAL.Enum.EmployePosition;
using FluentValidation;

namespace DepartmentManger.BL.DTOs.EmployeeDTOs
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public EmployeePosition Position { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
    }
    public class EmployeeDtoValidation : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name cannot be null")
                .MaximumLength(30).WithMessage("Maximum length is 30")
                .MinimumLength(3).WithMessage("Minumum length is 3");
            RuleFor(x => x.SurName).NotEmpty().NotNull().WithMessage("Surname cannot be null")
                .MaximumLength(40).WithMessage("Maximum length is 40")
                .MinimumLength(5).WithMessage("Minumum length is 5");
            RuleFor(b => b.Salary).NotEmpty().NotNull()
               .WithMessage("Salary cannot be null or empty")
               .GreaterThan(0).WithMessage(" Salary can not be below 0");
        }
    }
}
