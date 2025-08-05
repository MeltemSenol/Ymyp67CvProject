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
using Ymyp67CvProject.Entity.Dtos.Contact;

namespace Ymyp67CvProject.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ContactManager(IContactRepository contactRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<ContactResponseDto>> AddAsync(ContactCreateRequestDto dto)
        {
            try
            {
                var contact = _mapper.Map<Contact>(dto);
                await _contactRepository.AddAsync(contact);
                await _unitOfWork.CommitAsync();
                var response= _mapper.Map<ContactResponseDto>(contact);
                return new SuccessDataResult<ContactResponseDto>(response, ResultMessages.SuccessCreated);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<ContactResponseDto>(e.Message);
            }
        }
         public async Task<IResult> UpdateAsync(ContactUpdateRequestDto dto)
        {
            try
            {
                var contact = _mapper.Map<Contact>(dto);
                contact.UpdateAt = DateTime.Now;
                _contactRepository.Update(contact);
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
                var contact = await _contactRepository.GetAsync(c => c.Id == id);
                if (contact == null)
                {
                    return new ErrorResult(ResultMessages.ErrorGet);
                }
                contact.UpdateAt = DateTime.Now;
                contact.IsDeleted = true;
                contact.IsActive = false;
                _contactRepository.Update(contact);
                await _unitOfWork.CommitAsync();
                return new SuccessResult(ResultMessages.SuccessDeleted);
            }
            catch (Exception e)
            {

                return new ErrorResult(e.Message);
            }

        }

        public async Task<IDataResult<ContactResponseDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var contact = await _contactRepository.GetAsync(c => c.Id == id);
                if(contact == null)
                {
                    return new ErrorDataResult<ContactResponseDto>(ResultMessages.ErrorGet);
                }
                var response= _mapper.Map<ContactResponseDto>(contact);
                return new SuccessDataResult<ContactResponseDto>(response, ResultMessages.SuccessGet);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<ContactResponseDto>(e.Message);
            }
        }
        public async Task<IDataResult<IEnumerable<ContactResponseDto>>> GetAllAsync()
        {
            try
            {
                var contacts= await _contactRepository.GetAll(c=>!c.IsDeleted).ToListAsync();
                if (contacts == null)
                {
                    return new ErrorDataResult<IEnumerable<ContactResponseDto>>(ResultMessages.ErrorListed);
                }
                var dtos = _mapper.Map<IEnumerable<ContactResponseDto>>(contacts);
                return new SuccessDataResult<IEnumerable<ContactResponseDto>>(dtos, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {

              return new ErrorDataResult<IEnumerable<ContactResponseDto>>(e.Message);
            }
        }

        public async Task<IDataResult<IEnumerable<ContactResponseDto>>> GetContactListByCityAsync(string city)
        {
            try
            {
                var contacts = await _contactRepository.GetAll(c =>!c.IsDeleted && c.City == city).ToListAsync();
                if(contacts == null)
                {
                    return new ErrorDataResult<IEnumerable<ContactResponseDto>>(ResultMessages.ErrorListed);
                }
                var dtos = _mapper.Map<IEnumerable<ContactResponseDto>>(contacts);
                return new SuccessDataResult<IEnumerable<ContactResponseDto>>(dtos, ResultMessages.SuccessListed);
            }
            catch (Exception e)
            {

              return new ErrorDataResult<IEnumerable<ContactResponseDto>>(e.Message);
            }
        }

        
    }
}
