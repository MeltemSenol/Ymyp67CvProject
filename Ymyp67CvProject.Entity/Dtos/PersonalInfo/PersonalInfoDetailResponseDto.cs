using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.PersonalInfo
{
    public sealed record PersonalInfoDetailResponseDto(
        Guid id,
        string FirstName,
        string LastName,
        string ImageUrl,
        bool MaritalStatus,
        string Gender,
        string DrivingLicence,
        DateTime BirthDate,
        string BirthPlace,
        string Nationality,
        bool IsActive,
        bool IsDeleted):IDetailDto;


}
