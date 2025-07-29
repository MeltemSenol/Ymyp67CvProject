using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Language
{
    public sealed record class LanguageUpdateRequestDto(
        Guid id,
        string Name,
        byte Level,
        bool IsActive,
        bool IsDeleted) : IUpdateDto
    {
       
    }
}
