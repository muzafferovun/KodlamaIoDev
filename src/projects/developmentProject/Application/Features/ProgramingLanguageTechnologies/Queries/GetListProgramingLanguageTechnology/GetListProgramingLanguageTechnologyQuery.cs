using Application.Features.ProgramingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguageTechnologies.Queries.GetListProgramingLanguageTechnology
{
    public class GetListProgramingLanguageTechnologyQuery : IRequest<ProgramingLanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgramingLanguageTechnologyQueryHandler : IRequestHandler<GetListProgramingLanguageTechnologyQuery, ProgramingLanguageTechnologyListModel>
        {
            private readonly IProgramingLanguageTechnologyRepository _programingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgramingLanguageTechnologyQueryHandler(IProgramingLanguageTechnologyRepository programingLanguageTechnologyRepository, IMapper mapper)
            {
                _programingLanguageTechnologyRepository = programingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgramingLanguageTechnologyListModel> Handle(GetListProgramingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgramingLanguageTechnology> programingLanguageTechnologies = await _programingLanguageTechnologyRepository.GetListAsync(include:
                                                          m => m.Include(c => c.ProgramingLanguage),
                                                          index: request.PageRequest.Page,
                                                          size: request.PageRequest.PageSize
                                                          );
                //dataModel
                ProgramingLanguageTechnologyListModel mappedModels = _mapper.Map<ProgramingLanguageTechnologyListModel>(programingLanguageTechnologies);
                return mappedModels;
            }
        }

    }
}