using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Dtos.Certificate
{
    public class CertificateResponseDto(
        Guid id,
        string Title,
        string Degree,
        string Organisation,
        string Description,
        DateTime DateAt
        ) :IResponseDto;
}
