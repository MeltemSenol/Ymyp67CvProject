using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.About
{
    public sealed record AboutUpdateDto(
       Guid Id,
       string Description,
       byte Order,
       bool IsActive,
       bool IsDeleted) : IUpdateDto;
}
