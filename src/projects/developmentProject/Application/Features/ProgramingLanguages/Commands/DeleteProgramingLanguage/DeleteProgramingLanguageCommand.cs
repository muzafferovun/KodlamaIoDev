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

namespace Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage
{
    public class DeleteProgramingLanguageCommand:IRequest<ProgramingLanguageDeleteByIdDto>
    {
        public int Id { get; set; }
        public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteProgramingLanguageCommand, ProgramingLanguageDeleteByIdDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public DeleteProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }
            public async Task<ProgramingLanguageDeleteByIdDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBusinessRules.ProgramingLanguageIsExistWhenDeleted(request.Id);
                ProgramingLanguage programingLanguage = await _programingLanguageRepository.GetAsync(d=>d.Id==request.Id);
                await _programingLanguageRepository.DeleteAsync(programingLanguage);
                ProgramingLanguageDeleteByIdDto programingLanguageDeleteByIdDto = _mapper.Map<ProgramingLanguageDeleteByIdDto>(programingLanguage);
                return programingLanguageDeleteByIdDto;
            }
        }
    }
}
