using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentManger.DAL.Enum.EmployePosition;

namespace DepartmentManger.DAL.Entities
{
    public class Employee:AuditableEntity
    {
        public string Name { get; set; }
        public string SurName {  get; set; }
        public EmployeePosition Position { get; set; }  
        public int Salary {  get; set; }

        public Department Department { get; set; }
        public int DepartmentId {get; set; }
    }
}
