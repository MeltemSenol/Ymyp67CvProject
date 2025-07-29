using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.About
{
    public sealed record AboutDetailResponseDto(
       Guid Id,
       string Description, 
       byte Order,
       bool IsActive,
       bool IsDeleted) : IDetailDto;
}
