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
using Ymyp67CvProject.Entity.Dtos.PersonalInfo;

namespace Ymyp67CvProject.Business.Concrete
{
    public class PersonalInfoManager : IPersonalInfoService
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;  
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PersonalInfoManager(IPersonalInfoRepository personalInfoRepository,IMapper mapper, IUnitOfWork unitOfWork)
        {
            _personalInfoRepository = personalInfoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<PersonalInfoResponseDto>> AddAsync(PersonalInfoCreateRequestDto dto)
        {
            try
            {
                var personalInfo=_mapper.Map<PersonalInfo>(dto);
                await _personalInfoRepository.AddAsync(personalInfo);
                await _unitOfWork.CommitAsync();
                var response = _mapper.Map<PersonalInfoResponseDto>(personalInfo);
                return new SuccessDataResult<PersonalInfoResponseDto>(response, ResultMessages.SuccessCreated);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<PersonalInfoResponseDto>(e.Message);
            }
        }
        public async Task<IResult> UpdateAsync(PersonalInfoUpdateRequestDto dto)
        {
            try
            {
                var personalInfo = _mapper.Map<PersonalInfo>(dto);
                personalInfo.UpdateAt = DateTime.Now;
                _personalInfoRepository.Update(personalInfo);
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
                var personalInfo = await _personalInfoRepository.GetAsync(p => p.Id == id);
                if (personalInfo == null)
                {
                    return new ErrorResult(ResultMessages.ErrorGet);
                }
                personalInfo.UpdateAt = DateTime.Now;
                personalInfo.IsDeleted = true;
                personalInfo.IsActive = false;
                _personalInfoRepository.Update(personalInfo);
                await _unitOfWork.CommitAsync();
                return new SuccessResult(ResultMessages.SuccessDeleted);
            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message);
            }
        }
        public async Task<IDataResult<PersonalInfoResponseDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var personalInfo = _personalInfoRepository.GetAsync(p => p.Id == id);
                if (personalInfo == null)
                {
                    return new ErrorDataResult<PersonalInfoResponseDto>(ResultMessages.ErrorGet);
                }
                var response = _mapper.Map<PersonalInfoResponseDto>(personalInfo);
                return new SuccessDataResult<PersonalInfoResponseDto>(response, ResultMessages.SuccessGet);
            }
            catch (Exception e)
            {

               return new ErrorDataResult<PersonalInfoResponseDto>(e.Message);
            }
        }
        public async Task<IDataResult<IEnumerable<PersonalInfoResponseDto>>> GetAllAsync()
        {
            try
            {
                var personalInfos = await _personalInfoRepository.GetAll(p => !p.IsDeleted).ToListAsync();
                if (personalInfos == null) 
                {
                    return new ErrorDataResult<IEnumerable<PersonalInfoResponseDto>>(ResultMessages.ErrorListed);
                }
                var dtos= _mapper.Map<IEnumerable<PersonalInfoResponseDto>>(personalInfos);
                return new SuccessDataResult<IEnumerable<PersonalInfoResponseDto>>(dtos, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<IEnumerable<PersonalInfoResponseDto>>(e.Message);
            }
        }

       

       

        
    }
}
