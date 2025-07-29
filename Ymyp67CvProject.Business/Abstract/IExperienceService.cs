using Core.Business;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;
using Ymyp67CvProject.Entity.Dtos.Experience;

namespace Ymyp67CvProject.Business.Abstract
{
    public interface IExperienceService:IGenericService<Experience,ExperienceResponseDto,
        ExperienceCreateRequestDto,ExperienceUpdateRequestDto,
        ExperienceDetailResponseDto>
    {
        Task<IDataResult<IEnumerable<Experience>>>GetExperiencesByCompanyAsync(string company);
    }
}
