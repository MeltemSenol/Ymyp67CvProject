using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ymyp67CvProject.Entity.Dtos.Language
{
    public sealed class LanguageResponseDto(
        Guid id,
        string Name,
        byte Level):IResponseDto;
}
