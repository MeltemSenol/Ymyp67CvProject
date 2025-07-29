using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Experience
{
    public sealed record ExperienceUpdateRequestDto(
       Guid id,
     string Title,
     string Company,
     string Description,
     DateTime StartDate,
     DateTime? EndDate,
     bool IsActive,
     bool IsDeleted) :IUpdateDto;
}
