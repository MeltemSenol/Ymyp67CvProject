using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.DataAccess.Abstract;
using Ymyp67CvProject.DataAccess.Context;
using Ymyp67CvProject.Entity.Concrete;

namespace Ymyp67CvProject.DataAccess.Concrete.EntityFramework
{
    public class EfPersonalInfoRepository : EfGenericRepository<PersonalInfo, Ymyp67CvProjectDbContext>, IPersonalInfoRepository
    {
        public EfPersonalInfoRepository(Ymyp67CvProjectDbContext context) : base(context)
        {
        }
    }
}
