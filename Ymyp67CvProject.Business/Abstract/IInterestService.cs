using Core.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;
using Ymyp67CvProject.Entity.Dtos.Interest;

namespace Ymyp67CvProject.Business.Abstract
{
    public interface IInterestService:IGenericService<Interest,InterestResponseDto,
        InterestCreateRequestDto,InterestUpdateRequestDto,InterestDetailResponseDto>
    {

    }
}
