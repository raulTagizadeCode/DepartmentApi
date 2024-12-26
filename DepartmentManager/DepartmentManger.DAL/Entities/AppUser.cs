using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DepartmentManger.DAL.Entities
{
    public class AppUser:IdentityUser
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
