using Application.Features.ProgramingLanguageTechnologies.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguageTechnologies.Models
{
    public class ProgramingLanguageTechnologyListModel:BasePageableModel
    {
        public IList<ProgramingLanguageTechnologyListDto> Items { get; set; }   
    }
}
