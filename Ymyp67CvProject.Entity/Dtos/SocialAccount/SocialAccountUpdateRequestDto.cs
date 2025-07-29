using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.SocialAccount
{
    public sealed record SocialAccountUpdateRequestDto(
        Guid id,
        string Name,
        string WebUrl,
        string UserName,
        string Icon,
        bool IsActive,
        bool IsDeleted) : IUpdateDto;
}
