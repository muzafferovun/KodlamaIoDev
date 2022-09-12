using Application.Features.ProgramingLanguageTechnologies.Models;
using Application.Features.ProgramingLanguageTechnologies.Queries.GetListProgramingLanguageTechnology;
using Application.Features.ProgramingLanguageTechnologies.Queries.GetListProgramingLanguageTechnologyDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguageTechnologyController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramingLanguageTechnologyQuery getListProgramingLanguageTechnologyQuery = new GetListProgramingLanguageTechnologyQuery { PageRequest = pageRequest };
            ProgramingLanguageTechnologyListModel result = await Mediator.Send(getListProgramingLanguageTechnologyQuery);
            return Ok(result);

        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListProgramingLanguageTechnologyDynamicQuery getListByDynamicModelQuery = new GetListProgramingLanguageTechnologyDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            ProgramingLanguageTechnologyListModel result = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(result);

        }
    }
}
