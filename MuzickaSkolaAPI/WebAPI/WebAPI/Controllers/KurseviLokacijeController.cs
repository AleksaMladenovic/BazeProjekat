using DatabaseAccess.DataProvider;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KurseviLokacijeController : ControllerBase
    {
        [HttpGet]
        [Route("{kursId}/Lokacije")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLokacijeZaKurs(int kursId)
        {
            var result = DataProviderAleksa.VratiSveLokacijeZaKurs(kursId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("{kursId}/DodajLokaciju/{adresaLokacije}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddLokacijaKursu(int kursId, string adresaLokacije)
        {
            var result = DataProviderAleksa.DodajLokacijuKursu(adresaLokacije, kursId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok("Uspešno dodata lokacija na kurs.");
        }

        [HttpDelete]
        [Route("{kursId}/UkloniLokaciju/{adresaLokacije}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RemoveLokacijaSaKursa(int kursId, string adresaLokacije)
        {
            var result = DataProviderAleksa.UkloniLokacijuIzKursa(kursId, adresaLokacije);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return NoContent(); // Vraćamo 204 No Content za uspešno brisanje
        }
    }
}
