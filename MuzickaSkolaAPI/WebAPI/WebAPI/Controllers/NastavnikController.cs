
using Microsoft.AspNetCore.Mvc;
using MuzickaSkolaLibrary;
using DatabaseAccess.DTOs;
using MuzickaSkolaWindowsForms;
using DatabaseAccess.DataProvider;
using NHibernate;
using MuzickaSkolaWindowsForms.Entiteti;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NastavnikController:ControllerBase
    {
        [HttpGet("PreuzmiSveNastavnike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSviNastavnici()
        {
            var result = await DataProvider.VratiSveNastavnikeAsync();

            if (result.IsError)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Data);
        }

        [HttpGet("PreuzmiNastavnika/{id}", Name = "GetNastavnikById")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetNastavnik(int id)
        {
            var result = await DataProvider.VratiNastavnikaAsync(id);

            if (result.IsError)
            {
                
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                
                return BadRequest(result.Error);
            }

        
            return Ok(result.Data);
        }

        [HttpPost("DodajNastavnika")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNastavnik([FromBody] NastavnikCreateView dto)
        {
            var result = await DataProvider.DodajNastavnikaAsync(dto);

            if (result.IsError)
            {
                return BadRequest(result.Error);
            }

            return StatusCode(201, $"Uspešno dodat nastavnik: {dto.Ime} {dto.Prezime}");
        }

        [HttpDelete("ObrisiNastavnika/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteNastavnik(int id)
        {
            var result = await DataProvider.ObrisiNastavnikaAsync(id);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }

            return StatusCode(201, $"Uspešno Obrisan nastavnik");
        }

        [HttpPut("AzurirajNastavnika/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateNastavnik(int id, [FromBody] NastavnikCreateView dto)
        {
            var result = await DataProvider.AzurirajNastavnikaAsync(id, dto);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }
            return Ok(result.Data);
        }

        [HttpGet("{id}/Kursevi")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetKurseviNastavnika(int id)
        {
            var result = await DataProvider.VratiSveKurseveNastavnikaAsync(id);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }


        [HttpGet("{id}/Casovi")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCasoviNastavnika(int id)
        {
            var result = await DataProvider.VratiSveCasoveNastavnikaAsync(id);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }

          
            return Ok(result.Data);
        }


        [HttpPut("{nastavnikId}/Mentor/{mentorId}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DodeliMentora(int nastavnikId, int mentorId)
        {
            var result = await DataProvider.DodeliMentoraAsync(nastavnikId, mentorId);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }

                return BadRequest(result.Error);
            }

            return  StatusCode(201, $"Nastavniku sa ID={nastavnikId} je uspešno dodeljen mentor sa ID={mentorId}.");
        }


        [HttpGet("PreuzmiSveKomisije")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSveKomisije()
        {
            var result = await DataProvider.VratiSveKomisijeAsync();

            if (result.IsError)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }


        [HttpGet("{id}/Clanovi")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClanoviKomisije(int id)
        {
            var result = await DataProvider.VratiClanoveKomisijeAsync(id);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }


        [HttpPost("Dodaj Komisiju")] 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNovaKomisija()
        {
            var result = await DataProvider.DodajNovuKomisijuAsync();

            if (result.IsError)
            {
                return BadRequest(result.Error);
            }

            return StatusCode(201, $"Komisija je uspesno kreirana");
        }


        [HttpPut("{id}/Komisije")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateNastavnikKomisije(int id, [FromBody] List<int> noveKomisijeIds)
        {
            if (noveKomisijeIds == null)
            {
                return BadRequest("Telo zahteva ne sme biti prazno.");
            }

            var result = await DataProvider.SacuvajIzmeneZaKomisijeAsync(id, noveKomisijeIds);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }

        [HttpDelete("{id} Obrisi Komisiju")] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteKomisija(int id)
        {
            var result = await DataProvider.ObrisiKomisijuAsync(id);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }


            return StatusCode(201, $"Uspešno Obrisana komisija");
        }

    }


}
