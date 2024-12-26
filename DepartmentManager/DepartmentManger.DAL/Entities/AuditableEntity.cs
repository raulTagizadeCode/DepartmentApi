using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentManger.DAL.Entities
{
    public abstract class AuditableEntity:BaseEntity
    {
        public DateTime CreateAtt {  get; set; }
        public string? CreateBy {  get; set; }

        public DateTime? UpdateAtt { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? DeleteAtt { get; set; }
        public string? DeleteBy { get; set; }

    }
}
