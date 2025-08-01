using AutoMapper;
using Core.UnitOfWorks;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Business.Abstract;
using Ymyp67CvProject.Business.Constants;
using Ymyp67CvProject.DataAccess.Abstract;
using Ymyp67CvProject.Entity.Concrete;
using Ymyp67CvProject.Entity.Dtos.Education;

namespace Ymyp67CvProject.Business.Concrete
{
    public class EducationManager : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public EducationManager(IEducationRepository educationRepository,IMapper mapper, IUnitOfWork unitOfWork)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<IDataResult<EducationResponseDto>> AddAsync(EducationCreateRequestDto dto)
        {
            try
            {
                var education = _mapper.Map<Education>(dto);
                await _educationRepository.AddAsync(education);
                await _unitOfWork.CommitAsync();
                var response=_mapper.Map<EducationResponseDto>(education);
                return new SuccessDataResult<EducationResponseDto>(response, ResultMessages.SuccessCreated);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<EducationResponseDto>(e.Message);
            }
        }
        public async Task<IResult> UpdateAsync(EducationUpdateRequestDto dto)
        {
            try
            {
                var education = _mapper.Map<Education>(dto);
                education.UpdateAt = DateTime.Now;
                _educationRepository.Update(education);
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
                var education=await _educationRepository.GetAsync(e => e.Id == id);
                if (education == null)
                {
                    return new ErrorResult(ResultMessages.ErrorGet);
                }
                education.UpdateAt = DateTime.Now;
                education.IsDeleted = true;
                education.IsActive = false;
                _educationRepository.Update(education);
                await _unitOfWork.CommitAsync();
                return new SuccessResult(ResultMessages.SuccessDeleted);
            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message);            
            }
        }
        public async Task<IDataResult<EducationResponseDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var education = await _educationRepository.GetAsync(e => e.Id == id);
                if (education == null)
                {
                    return new ErrorDataResult<EducationResponseDto>(ResultMessages.ErrorGet);
                }
                var response = _mapper.Map<EducationResponseDto>(education);    
                return new SuccessDataResult<EducationResponseDto>(response, ResultMessages.SuccessGet);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<EducationResponseDto>(e.Message);
            }
        }
        public async Task<IDataResult<IEnumerable<EducationResponseDto>>> GetAllAsync()
        {
            try
            {
                var education=await _educationRepository.GetAll(e => !e.IsDeleted).ToListAsync();
                if (education == null)
                {
                    return new ErrorDataResult<IEnumerable<EducationResponseDto>>(ResultMessages.ErrorListed);
                }
                var dtos= _mapper.Map<IEnumerable<EducationResponseDto>>(education);
                return new SuccessDataResult<IEnumerable<EducationResponseDto>>(dtos, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<IEnumerable<EducationResponseDto>>(e.Message);
            }
        }
        public async Task<IDataResult<Education>> GetEducationAsync(string grade)
        {
            try
            {
                var education = await _educationRepository.GetAsync(e => e.Grade == grade);
                if (education == null)
                {
                    return new ErrorDataResult<Education>(ResultMessages.ErrorGet);
                }
                var dto= _mapper.Map<Education>(education);
                return new SuccessDataResult<Education>(dto, ResultMessages.SuccessGet);
            }
            catch (Exception e)
            {

               return new ErrorDataResult<Education>(e.Message);
            }
        }
        public async Task<IResult> AnyContinueAsync()
        {
            try
            {
                var education = await _educationRepository.AnyAsync(e => e.EndDate == null);
                if (!education)
                {
                    return new SuccessResult(ResultMessages.ErrorGet);   //Devam ettiği okul yoksa da başarılı döner fakat hata mesajı devam ettiği okul yok anlamında ErrorGet olarak verilir.
                }
                return new SuccessResult(ResultMessages.SuccessGet);
                ;            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message);
            }
        }

       

        

       

       
       
    }
}
