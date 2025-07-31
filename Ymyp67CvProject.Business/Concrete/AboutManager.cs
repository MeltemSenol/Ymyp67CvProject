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

        public async Task<IDataResult<AboutResponseDto>> AddAsync(AboutCreateRequestDto dto)
        {
            try
            {
                var about = _mapper.Map<About>(dto);
                await _aboutRepository.AddAsync(about);

                await _unitOfWork.CommitAsync();

                var response=_mapper.Map<AboutResponseDto>(about);
               return new SuccessDataResult<AboutResponseDto>(response, ResultMessages.SuccessAboutCreated);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<AboutResponseDto>(e.Message);
            }
        }
        public async Task<IResult> UpdateAsync(AboutUpdateRequestDto dto)
        {
            try
            {
                var about = _mapper.Map<About>(dto);  //update ve remove için async yok. Fakat belki başka metodlar yazarız buraya diye public async olarak tanımladık.
                about.UpdateAt = DateTime.Now;
                _aboutRepository.Update(about); 
                await _unitOfWork.CommitAsync();
                return new SuccessResult(ResultMessages.SuccessAboutUpdated);
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
                var about = await _aboutRepository.GetAsync(a=>a.Id==id);
                if(about is null)
                {
                    return new ErrorResult(ResultMessages.ErrorAboutGet);
                }
                about.UpdateAt = DateTime.Now;
                about.IsDeleted = true; 
                about.IsActive = false; 
                _aboutRepository.Update(about);
                await _unitOfWork.CommitAsync();
                return new SuccessResult(ResultMessages.SuccessAboutDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
        public async Task<IDataResult<AboutResponseDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var about = await _aboutRepository.GetAsync(a => a.Id == id);
                if (about is null)
                {
                    return new ErrorDataResult<AboutResponseDto>(ResultMessages.ErrorAboutGet);
                }
                var response = _mapper.Map<AboutResponseDto>(about);
                return new SuccessDataResult<AboutResponseDto>(response,ResultMessages.SuccessGet);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<AboutResponseDto>(e.Message);
            }
        }
        public async Task<IDataResult<IEnumerable<AboutResponseDto>>> GetAllAsync()
        {
            try
            {
                var abouts=await _aboutRepository.GetAll(a=>!a.IsDeleted).ToListAsync();
                if (abouts is null)
                {
                    return new ErrorDataResult<IEnumerable<AboutResponseDto>>(ResultMessages.ErrorAboutListed);
                }
                var dtos= _mapper.Map<IEnumerable<AboutResponseDto>>(abouts);
                return new SuccessDataResult<IEnumerable<AboutResponseDto>>(dtos,ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<AboutResponseDto>>(e.Message);
            }
        }

        

      
       
    }
}
