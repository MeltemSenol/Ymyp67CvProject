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
    public interface IAboutService:IGenericService<About>
    {
        //Ekstradan sadece certificate'i ilgilendiren bir metot ekliyoruz.
        Task<IDataResult<IEnumerable<Certificate>>> GetCertificatesByOrganisationAsync();

    }
}
