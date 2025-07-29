using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Skill
{
    public sealed record SkillCreateRequestDto(
       string Title,
        string Icon,
        bool IsProgramLanguageAndTool) :ICreateDto;

}
