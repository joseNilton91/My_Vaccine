using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Services.Contract;
using MyVaccineWebApi.Services.Implements;

namespace MyVaccineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineService _vaccineService;

        public VaccineController(IVaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }

        [HttpGet("{IdVaccine}")]
        public async Task<IActionResult> GetVaccine(int IdVaccine)
        {
            var vaccine = await _vaccineService.GetVaccine(IdVaccine);
            if (vaccine == null) return NotFound();
            return Ok(vaccine);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVaccines()
        {
            var vaccines = await _vaccineService.GetAllVaccines();
            return Ok(vaccines);
        }

        [HttpPost]
        public async Task<IActionResult> AddVaccine(Vaccine vaccine)
        {
            
            await _vaccineService.AddVaccine(vaccine);
            return CreatedAtAction(nameof(GetVaccine), new { IdVaccine = vaccine.IdVaccine }, vaccine);
        }

        [HttpPut("{IdVaccine}")]
        public async Task<IActionResult> UpdateVaccine(int IdVaccine, Vaccine vaccine)
        {
            if (IdVaccine != vaccine.IdVaccine) return BadRequest();
            await _vaccineService.UpdateVaccine(vaccine);
            return NoContent();
        }

        [HttpDelete("{IdVaccine}")]
        public async Task<IActionResult> DeleteVaccine(int IdVaccine)
        {
            await _vaccineService.DeleteVaccine(IdVaccine);
            return Ok(new { message = "vaccine delete whith success" }); ;
        }
    }
}
