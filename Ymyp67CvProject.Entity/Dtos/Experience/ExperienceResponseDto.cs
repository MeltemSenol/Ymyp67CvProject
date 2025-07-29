using Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Dtos.Experience
{
    public sealed record ExperienceResponseDto(
     Guid id,
     string Title,
     string Company,
     string Description,
     DateTime StartDate,
     DateTime? EndDate
     ) :IResponseDto;
}
