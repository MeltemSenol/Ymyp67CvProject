using Core.Business;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;

namespace Ymyp67CvProject.Business.Abstract
{
    public interface ISkillService:IGenericService<Skill>
    {
        Task<IDataResult<IEnumerable<Skill>>> GetSkillsProgramLanguageAsync(bool program);
        Task<IDataResult<IEnumerable<Skill>>> GetSkillsToolsAsync(bool tools);
    }
}
