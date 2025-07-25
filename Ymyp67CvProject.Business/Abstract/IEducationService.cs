using Core.Business;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;

namespace Ymyp67CvProject.Business.Abstract
{
    public interface IEducationService:IGenericService<Education>
    {
        Task<IDataResult<Education>> GetEducationAsync(string grade);
        Task<IResult> AnyContinueAsync();
    }
}
