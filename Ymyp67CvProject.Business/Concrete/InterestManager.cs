using AutoMapper;
using Core.UnitOfWorks;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Business.Abstract;
using Ymyp67CvProject.Business.Constants;
using Ymyp67CvProject.DataAccess.Abstract;
using Ymyp67CvProject.Entity.Concrete;
using Ymyp67CvProject.Entity.Dtos.Interest;

namespace Ymyp67CvProject.Business.Concrete
{
    public class InterestManager : IInterestService
    {
        private readonly IInterestRepository _interestRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public InterestManager(IInterestRepository ınterestRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _interestRepository = ınterestRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<InterestResponseDto>> AddAsync(InterestCreateRequestDto dto)
        {
            try
            {
                var interest = _mapper.Map<Interest>(dto);
                await _interestRepository.AddAsync(interest);
                await _unitOfWork.CommitAsync();
                var response=_mapper.Map<InterestResponseDto>(interest);
                return new SuccessDataResult<InterestResponseDto>(response, ResultMessages.SuccessCreated);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<InterestResponseDto>(e.Message);
            }
        }
        public async Task<IResult> UpdateAsync(InterestUpdateRequestDto dto)
        {
            try
            {
                var interest = _mapper.Map<Interest>(dto);
                interest.UpdateAt= DateTime.Now;
                _interestRepository.Update(interest);
                await _unitOfWork.CommitAsync();
                return new SuccessResult(ResultMessages.SuccesstUpdated);

            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message);
            }
        }
        public async Task<IResult> RemoveAsync(Guid id)
        {
            try
            {
                var interest= await _interestRepository.GetAsync(i=> i.Id == id);
                if(interest == null)
                {
                    return new ErrorResult(ResultMessages.ErrorGet);
                }
                interest.UpdateAt = DateTime.Now;
                interest.IsDeleted = true;
                interest.IsActive = false;
                _interestRepository.Update(interest);
                await _unitOfWork.CommitAsync();
                return new SuccessResult(ResultMessages.SuccessDeleted);
            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message);
            }
        }
        public async Task<IDataResult<InterestResponseDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var interest = await _interestRepository.GetAsync(i => i.Id == id && !i.IsDeleted);
                if (interest == null)
                {
                    return new ErrorDataResult<InterestResponseDto>(ResultMessages.ErrorGet);
                }
                var response = _mapper.Map<InterestResponseDto>(interest);
                return new SuccessDataResult<InterestResponseDto>(response, ResultMessages.SuccessGet);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<InterestResponseDto>(e.Message);
            }
        }
        public async Task<IDataResult<IEnumerable<InterestResponseDto>>> GetAllAsync()
        {
            try
            {
                var interests = await _interestRepository.GetAll(i => !i.IsDeleted).OrderBy(i=>i.Order).ToListAsync(); //Order kolonuna göre sıraladık. hangi ilgi alanı önce yazılacaksa ona göre sıralama yapıldı.
                if (interests == null)
                {
                    return new ErrorDataResult<IEnumerable<InterestResponseDto>>(ResultMessages.ErrorListed);
                }
                var dtos= _mapper.Map<IEnumerable<InterestResponseDto>>(interests);
                return new SuccessDataResult<IEnumerable<InterestResponseDto>>(dtos, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<IEnumerable<InterestResponseDto>>(e.Message);
            }
        }

       

        

        
    }
}
