using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Concrete
{
    public sealed class Education:BaseEntity
    {
        public string School { get; set; }
        public string Section { get; set; }
        public string Department { get; set; } 
        public decimal GPA { get; set; }
        public string Grade { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
