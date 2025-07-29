using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Interest
{
    public sealed record InterestCreateRequestDto(
       string Description,
       byte Order) :ICreateDto;

}
