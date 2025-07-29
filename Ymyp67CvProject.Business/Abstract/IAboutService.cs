using Core.Business;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;
using Ymyp67CvProject.Entity.Dtos.About;

namespace Ymyp67CvProject.Business.Abstract
{
    public interface IAboutService:IGenericService<About,AboutResponseDto,
        AboutCreateRequestDto,AboutUpdateRequestDto,AboutDetailResponseDto>
    {
        
    }
}
