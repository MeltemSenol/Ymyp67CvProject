using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Contact
{
    public sealed record ContactUpdateRequestDto(
        Guid id,
        string Address,
        string City,
        string Town,
        string Phone,
        string Email,
        bool IsActive,
        bool IsDeleted
        ) : IUpdateDto;

}
