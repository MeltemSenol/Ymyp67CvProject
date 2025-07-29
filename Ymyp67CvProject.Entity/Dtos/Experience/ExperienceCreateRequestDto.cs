using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Experience
{
    public sealed record ExperienceCreateRequestDto(
       string Title,
     string Company,
     string Description,
     DateTime StartDate,
     DateTime? EndDate) :ICreateDto;
}
