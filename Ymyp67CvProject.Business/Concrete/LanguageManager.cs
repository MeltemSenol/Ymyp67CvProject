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
using Ymyp67CvProject.Entity.Dtos.Language;

namespace Ymyp67CvProject.Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LanguageManager(ILanguageRepository languageRepository,IMapper mapper, IUnitOfWork unitOfWork)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<LanguageResponseDto>> AddAsync(LanguageCreateRequestDto dto)
        {
            try
            {
                var language = _mapper.Map<Language>(dto);
                await _languageRepository.AddAsync(language);
                await _unitOfWork.CommitAsync();
                var response = _mapper.Map<LanguageResponseDto>(language);
                return new SuccessDataResult<LanguageResponseDto>(response, ResultMessages.SuccessCreated);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<LanguageResponseDto>(e.Message);
            }
        }
        public async Task<IResult> UpdateAsync(LanguageUpdateRequestDto dto)
        {
            try
            {
                var language = _mapper.Map<Language>(dto);
                language.UpdateAt = DateTime.Now;
                _languageRepository.Update(language);
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
var language=await _languageRepository.GetAsync(l => l.Id == id);
                if (language == null)
                {
                    return new ErrorResult(ResultMessages.ErrorGet);
                }
                language.UpdateAt = DateTime.Now;
                language.IsDeleted = true;
                language.IsActive = false;
                _languageRepository.Update(language);
                await _unitOfWork.CommitAsync();
                return new SuccessResult(ResultMessages.SuccessDeleted);
            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message);
            }
        }
        public async Task<IDataResult<LanguageResponseDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var language = await _languageRepository.GetAsync(l => l.Id == id);
                if (language == null)
                {
                    return new ErrorDataResult<LanguageResponseDto>(ResultMessages.ErrorGet);
                }
                var response = _mapper.Map<LanguageResponseDto>(language);
                return new SuccessDataResult<LanguageResponseDto>(response, ResultMessages.SuccessGet);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<LanguageResponseDto>(e.Message);
            }
        }
        public async Task<IDataResult<IEnumerable<LanguageResponseDto>>> GetAllAsync()
        {
            try
            {
                var languages=await _languageRepository.GetAll(l=> !l.IsDeleted).ToListAsync();
                if (languages == null)
                {
                    return new ErrorDataResult<IEnumerable<LanguageResponseDto>>(ResultMessages.ErrorGet);
                }
                var dtos= _mapper.Map<IEnumerable<LanguageResponseDto>>(languages);
                return new SuccessDataResult<IEnumerable<LanguageResponseDto>>(dtos, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<IEnumerable<LanguageResponseDto>>(e.Message);
            }
        }

        
        public async Task<IDataResult<IEnumerable<LanguageResponseDto>>> GetLanguagesGratherLevelAsync(byte level)
        {
            try
            {
                var languages=await _languageRepository.GetAll(l => l.Level > level && !l.IsDeleted).ToListAsync();
                if(languages==null)
                {
                    return new ErrorDataResult<IEnumerable<LanguageResponseDto>>(ResultMessages.ErrorListed);
                }
                var dtos = _mapper.Map<IEnumerable<LanguageResponseDto>>(languages);
                return new SuccessDataResult<IEnumerable<LanguageResponseDto>>(dtos, ResultMessages.SuccessListed);

            }
            catch (Exception e)
            {

                return new ErrorDataResult<IEnumerable<LanguageResponseDto>>(e.Message);
            }
        }

        

        
    }
}
