using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Dtos.Contact
{
    public sealed record ContactResponseDto(
        Guid id,
        string Address,
        string City,
        string Town,
        string Phone,
        string Email
        ):IResponseDto;

}
