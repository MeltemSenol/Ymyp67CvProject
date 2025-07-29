using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Dtos.Interest
{
    public sealed record InterestResponseDto(
       Guid id,
       string Description,
       byte Order): IResponseDto;

}
