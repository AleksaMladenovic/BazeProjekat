using DatabaseAccess.DataProvider;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;
using MuzickaSkolaWindowsForms;
using ProdavnicaLibrary;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CasoviController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveCasoveZaNastavu/{nastavaId}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCasoviZaNastavu(int nastavaId)
        {
            var result = DataProviderAleksa.VratiSveCasoveZaNastavu(nastavaId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajCas")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddCas([FromBody] CasBasic casDto)
        {
            var result = DataProviderAleksa.DodajCas(casDto);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniCas")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ChangeCas([FromBody] CasBasic casDto)
        {
            var result = DataProviderAleksa.IzmeniCas(casDto);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiCas/{casId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCas(int casId)
        {
            var result = DataProviderAleksa.ObrisiCas(casId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return NoContent();
        }
    }
}
