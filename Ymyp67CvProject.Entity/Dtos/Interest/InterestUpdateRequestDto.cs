using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Interest
{
    public sealed record InterestUpdateRequestDto(
       Guid id,
       string Description,
       byte Order,
       bool IsActive,
       bool IsDeleted) :IUpdateDto;

}
