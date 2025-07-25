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
    public class EfAboutRepository : EfGenericRepository<About, Ymyp67CvProjectDbContext>, IAboutRepository
    {
        public EfAboutRepository(Ymyp67CvProjectDbContext context) : base(context)
        {
        }
    }
}
