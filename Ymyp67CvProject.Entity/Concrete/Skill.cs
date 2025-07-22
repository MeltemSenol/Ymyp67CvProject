using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Concrete
{
    public sealed class Skill:BaseEntity
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public bool IsProgramLanguageAndTool { get; set; }
    }
}
