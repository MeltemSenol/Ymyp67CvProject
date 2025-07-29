using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.SocialAccount
{
    public sealed record SocialAccountCreateRequestDto(
       string Name,
        string WebUrl,
        string UserName,
        string Icon) :ICreateDto;
}
