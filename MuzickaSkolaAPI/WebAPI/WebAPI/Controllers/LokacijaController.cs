using DatabaseAccess.DataProvider;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;
using ProdavnicaLibrary;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LokacijaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveLokacije")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLokacije()
        {
            var result = DataProviderAleksa.VratiSveLokacije();
            if (result.IsError)
            {
                return StatusCode(400, result.Error?.Message);
            }

            return Ok(result.Data);
        }


        [HttpPost]
        [Route("DodajLokaciju")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult AddLokacija([FromBody] LokacijaView lokacija)
        {
            var result = DataProviderAleksa.DodajLokaciju(lokacija);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return StatusCode(201, result.Data);
        }

        [HttpPut]
        [Route("IzmeniLokaciju")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public IActionResult ChangeLokacija([FromBody] LokacijaView lokacija)
        {
            var result = DataProviderAleksa.IzmeniLokaciju(lokacija);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiLokaciju/{adresa}")] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult DeleteLokacija(string adresa)
        {
            var result = DataProviderAleksa.ObrisiLokaciju(adresa);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return NoContent();
        }


        [HttpGet]
        [Route("PreuzmiUcioniceZaLokaciju/{adresaLokacije}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUcionice(string adresaLokacije)
        {
            var result = DataProviderAleksa.VratiSveUcioniceZaLokaciju(adresaLokacije);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("DodajUcionicu/{adresaLokacije}")] 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult AddUcionica(string adresaLokacije, [FromBody] UcionicaView ucionica)
        {
            var result = DataProviderAleksa.DodajUcionicu(adresaLokacije, ucionica);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return StatusCode(201, result.Data);
        }

        [HttpPut]
        [Route("IzmeniUcionicu")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ChangeUcionica([FromBody] UcionicaView ucionica)
        {
            var result = DataProviderAleksa.IzmeniUcionicu(ucionica);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("ObrisiUcionicu/{adresaLokacije}/{nazivUcionice}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult DeleteUcionica(string adresaLokacije, string nazivUcionice)
        {
            var result = DataProviderAleksa.ObrisiUcionicu(adresaLokacije, nazivUcionice);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return NoContent(); 
        }
    }
}