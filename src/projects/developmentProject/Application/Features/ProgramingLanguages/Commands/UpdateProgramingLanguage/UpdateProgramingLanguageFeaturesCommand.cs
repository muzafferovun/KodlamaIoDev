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
    public partial class UpdateProgramingLanguageFeaturesCommand : IRequest<ProgramingLanguageFeaturesUpdateDto>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public class UpdateProgramingLanguageFeaturesCommandHandler : IRequestHandler<UpdateProgramingLanguageFeaturesCommand, ProgramingLanguageFeaturesUpdateDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public UpdateProgramingLanguageFeaturesCommandHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }
            public async Task<ProgramingLanguageFeaturesUpdateDto> Handle(UpdateProgramingLanguageFeaturesCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBusinessRules.ProgramingLanguageIsExistWhenFeaturesUpdated(request.Id);

                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(u => u.Id == request.Id);
                programingLanguage.Description = request.Description;   
                ProgramingLanguage updatedProgramingLanguage = await _programingLanguageRepository.UpdateAsync(programingLanguage);
                ProgramingLanguageFeaturesUpdateDto updatedProgramingLanguageDto = _mapper.Map<ProgramingLanguageFeaturesUpdateDto>(updatedProgramingLanguage);
                return updatedProgramingLanguageDto;
            }

        }
    }
}
