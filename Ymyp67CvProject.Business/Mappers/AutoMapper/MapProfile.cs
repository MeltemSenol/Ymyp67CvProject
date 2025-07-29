using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;
using Ymyp67CvProject.Entity.Dtos.About;
using Ymyp67CvProject.Entity.Dtos.Certificate;
using Ymyp67CvProject.Entity.Dtos.Contact;
using Ymyp67CvProject.Entity.Dtos.Education;
using Ymyp67CvProject.Entity.Dtos.Experience;
using Ymyp67CvProject.Entity.Dtos.Interest;
using Ymyp67CvProject.Entity.Dtos.Language;
using Ymyp67CvProject.Entity.Dtos.PersonalInfo;
using Ymyp67CvProject.Entity.Dtos.Skill;
using Ymyp67CvProject.Entity.Dtos.SocialAccount;

namespace Ymyp67CvProject.Business.Mappers.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<About, AboutResponseDto>();
            CreateMap<About, AboutDetailResponseDto>();
            CreateMap<AboutCreateRequestDto, About>();
            CreateMap<AboutUpdateRequestDto, About>();

            CreateMap<Certificate, CertificateResponseDto>();
            CreateMap<Certificate, CertificateDetailResponseDto>();
            CreateMap<CertificateCreateRequestDto,Certificate >();
            CreateMap<CertificateUpdateRequestDto,Certificate >();

            CreateMap<Contact, ContactReponseDto>();
            CreateMap<Contact, ContactDetailResponseDto>();
            CreateMap<ContactCreateRequestDto, Contact>();
            CreateMap<ContactUpdateRequestDto,Contact >();

            CreateMap<Education, EducationResponseDto>();
            CreateMap<Education, EducationDetailResponseDto>();
            CreateMap<EducationCreateRequestDto,Education >();
            CreateMap<EducationUpdateRequestDto, Education>();

            CreateMap<Experience, ExperienceResponseDto>();
            CreateMap<Experience, ExperienceDetailResponseDto>();
            CreateMap<ExperienceCreateRequestDto, Experience>();
            CreateMap<ExperienceUpdateRequestDto, Experience>();

            CreateMap<Interest, InterestResponseDto>();
            CreateMap<Interest, InterestDetailResponseDto>();
            CreateMap<InterestCreateRequestDto, Interest>();
            CreateMap<InterestUpdateRequestDto, Interest>();

            CreateMap<Language, LanguageResponseDto>();
            CreateMap<Language, LanguageDetailResponseDto>();
            CreateMap<LanguageCreateRequestDto, Language>();
            CreateMap<LanguageUpdateRequestDto, Language>();

            CreateMap<PersonalInfo, PersonalInfoResponseDto>();
            CreateMap<PersonalInfo, PersonalInfoDetailResponseDto>();
            CreateMap<PersonalInfoCreateRequestDto, PersonalInfo>();
            CreateMap<PersonalInfoUpdateRequestDto, PersonalInfo>();

            CreateMap<Skill, SkillResponseDto>();
            CreateMap<Skill, SkillDetailResponseDto>(); 
            CreateMap<SkillCreateRequestDto, Skill>();
            CreateMap<SkillUpdateRequestDto, Skill>();

            CreateMap<SocialAccount, SocialAccountResponseDto>();
            CreateMap<SocialAccount, SocialAccountDetailResponseDto>();
            CreateMap<SocialAccountCreateRequestDto, SocialAccount>();
            CreateMap<SocialAccountUpdateRequestDto, SocialAccount>();







        }
    }
}
