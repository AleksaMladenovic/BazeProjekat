using DatabaseAccess.DataProvider;
using Microsoft.AspNetCore.Mvc;
using MuzickaSkolaWindowsForms;
using MuzickaSkolaWindowsForms.Entiteti;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PrisustvoCasoviController:ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiPrisustvaZaCas/{casId}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPrisustvaZaCas(int casId)
        {
            var result = DataProviderAleksa.VratiPrisustvaZaCas(casId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajPrisustvo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddPrisustvo([FromBody] PrisustvoPregled prisustvoDto)
        {
            var result = DataProviderAleksa.DodajPrisustvo(prisustvoDto);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniPrisustvo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ChangePrisustvo([FromBody] PrisustvoPregled prisustvoDto)
        {
            var result = DataProviderAleksa.IzmeniPrisustvo(prisustvoDto);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("ObrisiPrisustvo/{polaznikId}/{casId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePrisustvo(int polaznikId, int casId)
        {
            var result = DataProviderAleksa.ObrisiPrisustvo(polaznikId,casId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return NoContent();
        }
    }
}
