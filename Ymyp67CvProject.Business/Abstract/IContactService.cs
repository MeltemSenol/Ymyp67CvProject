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
    public interface IContactService:IGenericService<Contact>
    {
        //Sadece contact ile ilgili ekstra bir metot ekliyoruz.
        Task<IDataResult<IEnumerable<Contact>>> GetContactListByCityAsync();
    }
}
