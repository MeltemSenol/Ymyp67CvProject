using Core.Business;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;
using Ymyp67CvProject.Entity.Dtos.SocialAccount;

namespace Ymyp67CvProject.Business.Abstract
{
    public interface ISocialAccountService:IGenericService<SocialAccount,SocialAccountResponseDto,
        SocialAccountCreateRequestDto,SocialAccountUpdateRequestDto,SocialAccountDetailResponseDto>
    {
        Task<IDataResult<SocialAccount>> GetSocialAccountByNameAsync();
        Task<IDataResult<IEnumerable<SocialAccount>>> GetSocialAccountsByUserNameAsync();
    }
}
