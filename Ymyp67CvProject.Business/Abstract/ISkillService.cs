using Core.Business;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;
using Ymyp67CvProject.Entity.Dtos.Skill;

namespace Ymyp67CvProject.Business.Abstract
{
    public interface ISkillService:IGenericService<Skill,SkillResponseDto,SkillCreateRequestDto,
        SkillUpdateRequestDto,SkillDetailResponseDto>
    {
        Task<IDataResult<IEnumerable<SkillResponseDto>>> GetSkillsProgramLanguageAsync();
        Task<IDataResult<IEnumerable<SkillResponseDto>>> GetWorkflowsAsync();
    }
}
