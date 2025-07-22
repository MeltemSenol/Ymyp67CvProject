using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Concrete
{
    public sealed class Contact:BaseEntity
    {
        public string Adress { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
