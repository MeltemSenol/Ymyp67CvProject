using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.DataAccess.Context;

namespace Ymyp67CvProject.DataAccess.UnitOfWork
{
    public class UnitOfWork(Ymyp67CvProjectDbContext context):IUnitOfWork
    {
        private readonly Ymyp67CvProjectDbContext _context=context;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
