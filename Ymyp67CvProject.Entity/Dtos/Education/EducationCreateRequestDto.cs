using Core.Entities;

namespace Ymyp67CvProject.Entity.Dtos.Education
{
    public sealed record EducationCreateRequestDto(
        string School,
        string Section,
        string Department,
        decimal GPA,
        string grade,
        DateTime StartDate,
        DateTime? EndDate
        ) :ICreateDto;
    
}
