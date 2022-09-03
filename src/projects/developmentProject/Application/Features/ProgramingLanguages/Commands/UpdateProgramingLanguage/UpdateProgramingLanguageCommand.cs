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

namespace Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage
{
    public partial class UpdateProgramingLanguageCommand : IRequest<ProgramingLanguageUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public class UpdateProgramingLanguageCommandHandler : IRequestHandler<UpdateProgramingLanguageCommand, ProgramingLanguageUpdateDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public UpdateProgramingLanguageCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }
            public async Task<ProgramingLanguageUpdateDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguageUpdateDto updateDto = _mapper.Map<ProgramingLanguageUpdateDto>(request);
                await _programingLanguageBusinessRules.ProgramingLanguageIsExistWhenUpdated(updateDto);
                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(updateDto);
                ProgramingLanguage? updatedProgramingLanguage = await _programingLanguageRepository.UpdateAsync(mappedProgramingLanguage);
                ProgramingLanguageUpdateDto updatedProgramingLanguageDto = _mapper.Map<ProgramingLanguageUpdateDto>(updatedProgramingLanguage);
                return updateDto;
            }

           
        }

    }
}
