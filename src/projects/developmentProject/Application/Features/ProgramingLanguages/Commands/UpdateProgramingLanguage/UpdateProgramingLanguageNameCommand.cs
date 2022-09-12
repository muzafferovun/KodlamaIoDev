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

   public partial class UpdateProgramingLanguageNameCommand : IRequest<ProgramingLanguageNameUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgramingLanguageNameCommandHandler : IRequestHandler<UpdateProgramingLanguageNameCommand, ProgramingLanguageNameUpdateDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public UpdateProgramingLanguageNameCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }
            public async Task<ProgramingLanguageNameUpdateDto> Handle(UpdateProgramingLanguageNameCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguageNameUpdateDto programingLanguageNameUpdateDto = _mapper.Map<ProgramingLanguageNameUpdateDto>(request);
                await _programingLanguageBusinessRules.ProgramingLanguageIsExistWhenNameUpdated(programingLanguageNameUpdateDto);

                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(u => u.Id == programingLanguageNameUpdateDto.Id);
                programingLanguage.Name = programingLanguageNameUpdateDto.Name;
                ProgramingLanguage updatedProgramingLanguage = await _programingLanguageRepository.UpdateAsync(programingLanguage);
                ProgramingLanguageNameUpdateDto updatedProgramingLanguageDto = _mapper.Map<ProgramingLanguageNameUpdateDto>(updatedProgramingLanguage);
                return updatedProgramingLanguageDto;
            }

        }
    }
}