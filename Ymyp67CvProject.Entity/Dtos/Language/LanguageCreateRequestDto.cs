using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Language
{
    public sealed record LanguageCreateRequestDto(
        string Name,
        byte Level) :ICreateDto;
}
