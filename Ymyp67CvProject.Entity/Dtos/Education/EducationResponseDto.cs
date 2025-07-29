using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Dtos.Education
{
    public sealed record EducationResponseDto(
        Guid id,
        string School,
        string Section,
        string Department,
        decimal GPA,
        string grade,
        DateTime StartDate,
        DateTime? EndDate
        ) :IResponseDto;
    
}
