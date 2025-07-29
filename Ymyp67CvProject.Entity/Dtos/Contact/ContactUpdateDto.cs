using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Contact
{
    public sealed record ContactUpdateDto(
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
