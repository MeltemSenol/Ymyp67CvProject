using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Certificate
{
    public sealed record CertificateDetailResponseDto(
        Guid Id,
        string Title,
        string Degree,
        string Organisation,
        string Description,
        DateTime DateAt,
        bool IsActive,
        bool IsDeleted
    ) : IDetailDto;
}
