using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Dtos.Skill
{
    public sealed record SkillResponseDto(
        Guid id,
        string Title,
        string Icon, 
        bool IsProgramLanguageAndTool):IResponseDto;

}
