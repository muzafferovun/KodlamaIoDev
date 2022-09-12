using Application.Features.ProgramingLanguageTechnologies.Dtos;
using Application.Features.ProgramingLanguageTechnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<ProgramingLanguageTechnology, ProgramingLanguageTechnologyListDto>().ForMember(c => c.ProgramingLanguageName, opt => opt.MapFrom(c => c.ProgramingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<ProgramingLanguageTechnology>, ProgramingLanguageTechnologyListModel>().ReverseMap();
        }
    }
}
