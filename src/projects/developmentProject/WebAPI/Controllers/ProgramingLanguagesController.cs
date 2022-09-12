using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries.DeleteByIdProgramingLanguage;
using Application.Features.ProgramingLanguages.Queries.GetByIdProgramingLanguage;
using Application.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguagesController:BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createProgramingLanguageCommand)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(createProgramingLanguageCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() { PageRequest = pageRequest };
            ProgramingLanguageListModel result = await Mediator.Send(getListProgramingLanguageQuery);
            return Ok(result);

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery getByIdProgramingLanguageQuery)
        {

            ProgramingLanguageGetByIdDto programingLanguageGetByIdDto = await Mediator.Send(getByIdProgramingLanguageQuery);
            return Ok(programingLanguageGetByIdDto);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById([FromRoute] DeleteProgramingLanguageCommand deleteProgramingLanguageCommand)
        {
            ProgramingLanguageDeleteByIdDto result = await Mediator.Send(deleteProgramingLanguageCommand);
            return Ok(result);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromQuery] UpdateProgramingLanguageCommand updateProgramingLanguageCommand)
        {
            ProgramingLanguageUpdateDto result = await Mediator.Send(updateProgramingLanguageCommand);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateFeatures")]
        public async Task<IActionResult> UpdateFeatures([FromQuery] UpdateProgramingLanguageFeaturesCommand updateProgramingLanguageCommand)
        {
            ProgramingLanguageFeaturesUpdateDto result = await Mediator.Send(updateProgramingLanguageCommand);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateName")]
        public async Task<IActionResult> UpdateName([FromQuery] UpdateProgramingLanguageNameCommand updateProgramingLanguageNameCommand)
        {
            ProgramingLanguageNameUpdateDto result = await Mediator.Send(updateProgramingLanguageNameCommand);
            return Ok(result);
        }


    }
}
