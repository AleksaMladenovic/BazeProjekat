using DatabaseAccess.DataProvider;
using Microsoft.AspNetCore.Mvc;
using MuzickaSkolaWindowsForms;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NastavaControler: ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveNastaveZaKurs/{kursId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNastaveZaKurs(int kursId)
        {
            var result = DataProviderAleksa.VratiSvuNastavuZaKurs(kursId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajNastavu")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddNastava([FromBody] NastavaBasic nastavaDto)
        {
            var result = DataProviderAleksa.DodajNastavu(nastavaDto);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniNastavu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ChangeNastava([FromBody] NastavaBasic nastavaDto)
        {
            var result = DataProviderAleksa.IzmeniNastavu(nastavaDto);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiNastavu/{nastavaId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteNastava(int nastavaId)
        {
            var result = DataProviderAleksa.ObrisiNastavu(nastavaId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return NoContent();
        }
    }
}
