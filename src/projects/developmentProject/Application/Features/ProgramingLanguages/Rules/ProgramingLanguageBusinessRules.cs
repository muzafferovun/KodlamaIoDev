using Application.Features.ProgramingLanguages.Dtos;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Rules
{
    public class ProgramingLanguageBusinessRules
    {
        private readonly IProgramingLanguageRepository _programingLanguageRepository;
        public ProgramingLanguageBusinessRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            _programingLanguageRepository= programingLanguageRepository;    

        }
        public async Task ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(p=>p.Name==name);
            if (result.Items.Any()) throw new BusinessException("ProgramingLanguage name exist");

        }
        public void ProgramingLanguageShouldExistWhenRequested(ProgramingLanguage programingLanguage)
        {
            if (programingLanguage == null) throw new BusinessException("Requested ProhramingLanguage does not exist");
        }
        public async Task ProgramingLanguageIsExistWhenDeleted(int id)
        {
            ProgramingLanguage? result = await _programingLanguageRepository.GetAsync(d => d.Id == id);
            if (result == null) throw new BusinessException("ProgramingLanguage does not exist");
        }


        public async Task ProgramingLanguageIsExistWhenUpdated(ProgramingLanguageUpdateDto programingLanguageUpdateDto)
        {
            IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(p => p.Name == programingLanguageUpdateDto.Name && p.Id != programingLanguageUpdateDto.Id);
            if (result.Items.Any()) throw new BusinessException("ProgramingLanguage name exist");

            //           IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(d => d.Id != programingLanguageUpdateDto.Id&&d.Name==programingLanguageUpdateDto.Name);
            //          if (result.Items.Any()) throw new BusinessException("Requested ProgramingLanguage name exist");
        }
        public async Task ProgramingLanguageIsExistWhenFeaturesUpdated(int id)
        {
            ProgramingLanguage? result = await _programingLanguageRepository.GetAsync(d => d.Id == id);
            if (result == null) throw new BusinessException("ProgramingLanguage does not exist");
        }
        public async Task ProgramingLanguageIsExistWhenNameUpdated(ProgramingLanguageNameUpdateDto programingLanguageUpdateDto)
        {
            IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(p => p.Name == programingLanguageUpdateDto.Name && p.Id != programingLanguageUpdateDto.Id);
            if (result.Items.Any()) throw new BusinessException("ProgramingLanguage name exist");

            //           IPaginate<ProgramingLanguage> result = await _programingLanguageRepository.GetListAsync(d => d.Id != programingLanguageUpdateDto.Id&&d.Name==programingLanguageUpdateDto.Name);
            //          if (result.Items.Any()) throw new BusinessException("Requested ProgramingLanguage name exist");
        }

        
    }
}
