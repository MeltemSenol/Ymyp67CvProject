using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ymyp67CvProject.Entity.Concrete;

namespace Ymyp67CvProject.Entity.Dtos.PersonalInfo
{
    public sealed record PersonalInfoResponseDto(
        Guid id,
        string FirstName,
        string LastName,
        string ImageUrl,
        bool MaritalStatus,
        string Gender,
        string DrivingLicence,
        DateTime BirthDate,
        string BirthPlace,
        string Nationality):IResponseDto;


}
