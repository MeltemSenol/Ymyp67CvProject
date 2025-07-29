using AutoMapper;
using Core.UnitOfWorks;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Business.Abstract;
using Ymyp67CvProject.DataAccess.Abstract;
using Ymyp67CvProject.Entity.Dtos.About;

namespace Ymyp67CvProject.Business.Concrete
{
    public class AboutManager: IAboutService

    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AboutManager(IAboutRepository aboutRepository,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _aboutRepository = _aboutRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<IDataResult<AboutResponseDto>> AddAsync(AboutCreateRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<AboutResponseDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<AboutResponseDto>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(AboutUpdateRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
