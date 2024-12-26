using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DepartmentManger.BL.DTOs.DepartmentDTOs
{
    public class DepartmentDto
    {
        public string DepartmentName { get; set; }
        public string DepartmentHead { get; set; }
        public int NumberEmployees { get; set; }
    }
    public class BookCreateDtoValidation : AbstractValidator<DepartmentDto>
    {
        public BookCreateDtoValidation() 
        {
            RuleFor(x => x.DepartmentName).NotEmpty().NotNull().WithMessage("DepartmentName cannot be null")
                .MaximumLength(30).WithMessage("Maximum length is 30")
                .MinimumLength(3).WithMessage("Minumum length is 3");
            RuleFor(x => x.DepartmentHead).NotEmpty().NotNull().WithMessage("DepartmentHead cannot be null")
                .MaximumLength(40).WithMessage("Maximum length is 40")
                .MinimumLength(5).WithMessage("Minumum length is 5");
            RuleFor(b => b.NumberEmployees).NotEmpty().NotNull()
               .WithMessage("NumberEmployees cannot be null or empty")
               .GreaterThan(0).WithMessage(" Quantity can not be below 0"); 
        }
    }
}
