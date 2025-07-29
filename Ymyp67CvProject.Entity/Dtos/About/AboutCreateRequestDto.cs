using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.About
{
    public sealed record AboutCreateRequestDto(
 
       string Description,
       byte Order) : ICreateDto;
}
