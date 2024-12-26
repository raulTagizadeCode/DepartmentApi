using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManger.DAL.Entities
{
    public class Department:AuditableEntity
    {
        public string DepartmentName { get; set; }
        public string DepartmentHead { get; set; }
        public int NumberEmployees {  get; set; }
        public List<Employee> Employees { get; set; }
    }
}
