using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Queries.DeleteByIdProgramingLanguage
{
    public class DeleteByIdProgramingLanguageQuery:IRequest<ProgramingLanguageDeleteByIdDto>
    {
        public int Id { get; set; }
        public class DeleteByIdProgramingLanguageQueryHandler : IRequestHandler<DeleteByIdProgramingLanguageQuery, ProgramingLanguageDeleteByIdDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public DeleteByIdProgramingLanguageQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<ProgramingLanguageDeleteByIdDto> Handle(DeleteByIdProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(p => p.Id == request.Id);
                ProgramingLanguageDeleteByIdDto programingLanguageDeleteByIdDto = _mapper.Map<ProgramingLanguageDeleteByIdDto>(programingLanguage);

   //              await _programingLanguageRepository.DeleteAsync(programingLanguage);
                return programingLanguageDeleteByIdDto;
            }
        }
    }
}
