using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;

namespace DepartmentManger.BL.DTOs.AppUSerDTOs
{
    public class AppUSerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class AppUSerDtoValidation : AbstractValidator<AppUSerDto>
    {
        public AppUSerDtoValidation()
        {
            RuleFor(b => b.FirstName).NotEmpty()
            .WithMessage("Name cannot be empty")
            .NotNull().WithMessage("Name cannot be null")
            .MaximumLength(30).WithMessage("Maximum length is 30");

            RuleFor(b => b.LastName).NotEmpty()
          .WithMessage("Surname cannot be empty")
          .NotNull().WithMessage("Surname cannot be null")
          .MaximumLength(50).WithMessage("Surname Maximum length is 50");

            RuleFor(b => b.Email).Must(e => BeValidEmailAddress(e)).WithMessage("Enter correct email address");

            RuleFor(b => b.PhoneNumber).Must(e => BeValidPhoneNumber(e)).WithMessage("Enter correcet PhoneNumber");
        }
             public bool BeValidEmailAddress(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success) { return true; }
            return false;
        }
        public bool BeValidPhoneNumber(string phonenNmber)
        {
            Regex regex = new Regex(@"^(?:\+994|0)(10|50|51|55|70|77|99)\d{7}$");
            Match match = regex.Match(phonenNmber);
            if (match.Success) { return true; }
            return false;
        }

    }
    }
