using Core.Business;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;
using Ymyp67CvProject.Entity.Dtos.Language;

namespace Ymyp67CvProject.Business.Abstract
{
    public interface ILanguageService:IGenericService<Language,LanguageResponseDto,
        LanguageCreateRequestDto,LanguageUpdateRequestDto,LanguageDetailResponseDto>
    {
        
        Task<IDataResult<IEnumerable<Language>>> GetLanguagesGratherLevelAsync(byte level);
        
    }
}
