using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Skill
{
    public sealed record SkillDetailResponseDto(
        Guid id,
        string Title,
        string Icon,
        bool IsProgramLanguageAndTool,
        bool IsActive,
        bool IsDeleted):IDetailDto;

}
