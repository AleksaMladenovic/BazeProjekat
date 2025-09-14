using Microsoft.AspNetCore.Mvc;
using MuzickaSkolaLibrary;
using DatabaseAccess.DTOs;
using MuzickaSkolaWindowsForms;
using DatabaseAccess.DataProvider;
using static DatabaseAccess.DTOs.PolaznikView;
using NHibernate;

namespace WebAPI.Controllers
    {
        [ApiController]
        [Route("[controller]")]
    
        public class PolaznikController : ControllerBase
        {
            [HttpGet("PreuzmiSvePolaznike")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public IActionResult GetSvePolaznike()
            {
                try
                {
                    
                    return Ok(DataProvider.VratiSvePolaznike());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("PreuzmiPolaznika/{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public IActionResult GetPolaznik(int id)
            {
                try
                {
                    return Ok(DataProvider.VratiPolaznika(id));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }


        [HttpPost]
        [Route("dodajOdraslogPolaznika")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOdrasliPolaznik([FromBody] OdrasliPolaznikCreateView polaznik)
        {
            var result = await DataProvider.DodajOdraslogPolaznikaAsync(polaznik);

            if (result.IsError)
            {
                return BadRequest(result.Error);
            }
            return StatusCode(201, $"Uspešno dodat polaznik: {polaznik.Ime} {polaznik.Prezime}");
        }

        [HttpPost]
        [Route("dodajDetePolaznika")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddDetePolaznik([FromBody] DetePolaznikCreateView polaznik)
        {
            var result = await DataProvider.DodajDetePolaznikaAsync(polaznik);

            if (result.IsError)
            {
                return BadRequest(result.Error);
            }

            return StatusCode(201, $"Uspešno dodat polaznik: {polaznik.Ime} {polaznik.Prezime}");
        }

        [HttpDelete]
        [Route("ObrisiPolaznika/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObrisiPolaznika(int id)
        {
            var result = await DataProvider.ObrisiPolaznikaAsync(id);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }

                return BadRequest(result.Error);
            }
            return StatusCode(201, $"Uspešno obrisan polaznik sa ID: {id}");
          
        }
        [HttpPut]
        [Route("IzmeniPolaznika/{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePolaznik(int id, [FromBody] PolaznikUpdateView p)
        {
            p.IdOsobe = id;

            var result = await DataProvider.AzurirajPolaznikaAsync(p);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }

            return StatusCode(201, $"Uspešno azuriran polaznik sa ID:{p.IdOsobe} ");
        }


        [HttpPut]
        [Route("IzmeniOdraslogPolaznika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeOdrasliPolaznik([FromBody] OdrasliPolaznikUpdateView p)
        {
            
            var dto = new OdrasliPolaznikUpdateView
            {
                IdOsobe = p.IdOsobe,
                Ime = p.Ime,
                Prezime = p.Prezime,
                Jmbg = p.Jmbg,
                Adresa = p.Adresa,
                Telefon = p.Telefon,
                Email = p.Email,
                Zanimanje = p.Zanimanje
            };

            var result = await DataProvider.AzurirajOdraslogPolaznikaAsync(dto);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }
            return StatusCode(201, $"Uspešno azuriran polaznik sa ID:{dto.IdOsobe} ");
        }

        [HttpPut]
        [Route("IzmeniDetePolaznika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeDetePolaznik([FromBody] DetePolaznikUpdateView p)
        {
            var result = await DataProvider.AzurirajDetePolaznikaAsync(p);

            var dto = new DetePolaznikUpdateView
            {
                IdOsobe = p.IdOsobe,
                Ime = p.Ime,
                Prezime = p.Prezime,
                Jmbg = p.Jmbg,
                Adresa = p.Adresa,
                Telefon = p.Telefon,
                Email = p.Email,
                Jbd= p.Jbd,
                IdRoditelja = p.IdRoditelja
            };
            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }

            return StatusCode(201, $"Uspešno azuriran polaznik sa ID:{p.IdOsobe} ");
        }

        [HttpGet("PreuzmiSveRoditelje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSviRoditelji()
        {
            var result =  DataProvider.VratiSveRoditelje();
            if (result.IsError) return BadRequest(result.Error);
            return Ok(result.Data);
        }

        [HttpGet("PreuzmiRoditelja/{id}", Name = "GetRoditelj")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoditelj(int id)
        {
            var result = await DataProvider.VratiRoditeljaAsync(id);
            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji")) return NotFound(result.Error);
                return BadRequest(result.Error);
            }
            return Ok(result.Data);
        }

        [HttpPost("DodajRoditelja")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddRoditelj([FromBody] RoditeljCreateView dto)
        {
            var result = await DataProvider.DodajRoditeljaAsync(dto);
            if (result.IsError) return BadRequest(result.Error);

            return StatusCode(201, $"Uspešno dodat roditelj {dto.Ime} {dto.Prezime}");
        }

        [HttpPut("AzurirajRoditelja/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRoditelj(int id, [FromBody] RoditeljUpdateView dto)
        {
            var result = await DataProvider.AzurirajRoditeljaAsync(id, dto);
            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji")) return NotFound(result.Error);
                return BadRequest(result.Error);
            }
            return StatusCode(201, $"Uspešno azuriran roditelj");
        }

        [HttpDelete("ObrisiRoditelja/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRoditelj(int id)
        {
            var result = await DataProvider.ObrisiRoditeljaAsync(id);
            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji")) return NotFound(result.Error);
                return BadRequest(result.Error);
            }
            return StatusCode(201, $"Uspešno obrisan roditelj sa ID: {id}");
        }

        [HttpGet("{id}/Kursevi")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPrijavljeniKursevi(int id)
        {
            var result = await DataProvider.VratiPrijavljeneKurseveAsync(id);

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

        [HttpPost]
        [Route("{polaznikId}/Kursevi/{kursId}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PrijaviPolaznikaNaKurs(int polaznikId, int kursId)
        {
            var result = await DataProvider.DodajPolaznikaNaKursAsync(polaznikId, kursId);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }

                return BadRequest(result.Error);
            }

            
            return Ok($"Polaznik sa ID={polaznikId} je uspešno prijavljen na kurs sa ID={kursId}.");
        }


        [HttpGet("{id}/Prisustva")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPrisustva(int id)
        {
            var result = await DataProvider.VratiPrisustvaAsync(id);

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

        [HttpGet("{id}/Ispiti")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPolozeniIspiti(int id)
        {
            var result = await DataProvider.VratiPolozeneIspiteAsync(id);

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

        [HttpPost("{id}/Ispiti")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddPolozeniIspit(int id, [FromBody] ZavrsniIspitCreateView dto)
        {
            var result = await DataProvider.DodajPolozeniIspitAsync(id, dto);

            if (result.IsError)
            {
                if (result.Error.Contains("ne postoji"))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }

       
            return StatusCode(201, result.Data);
        }
    }
}

