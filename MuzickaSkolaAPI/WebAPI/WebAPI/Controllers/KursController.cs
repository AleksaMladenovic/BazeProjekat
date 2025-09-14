using DatabaseAccess.DataProvider;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;
using MuzickaSkolaLibrary;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KursController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveKurseve")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKursevi()
        {
            var result = DataProvider.VratiSveKursevePregled();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajKurs")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddKurs([FromBody] KursBasic kursDto)
        {
            var result = DataProvider.DodajKurs(kursDto);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut]
        [Route("IzmeniKurs")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ChangeKurs([FromBody] KursBasic kursDto) 
        {
            var result = DataProvider.IzmeniKurs(kursDto);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiKurs/{kursId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteKurs(int kursId)
        {
            var result = DataProvider.ObrisiKurs(kursId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return NoContent();
        }
    }
}
