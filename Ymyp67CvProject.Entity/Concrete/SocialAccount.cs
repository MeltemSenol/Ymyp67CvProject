using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Concrete
{
    public sealed class SocialAccount:BaseEntity
    {
        public string Name { get; set; }
        public string WebUrl { get; set; }
        public string UserName { get; set; }
        public string Icon { get; set; }
    }
}
