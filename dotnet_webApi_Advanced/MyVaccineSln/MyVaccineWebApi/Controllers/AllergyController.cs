using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Services.Contract;
using MyVaccineWebApi.Services.Implements;

namespace MyVaccineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyService _allergyService;

        public AllergyController(IAllergyService allergyService)
        {
            _allergyService = allergyService;
        }

        [HttpGet("{IdAllergy}")]
        public async Task<IActionResult> GetAllergy(int IdAllergy)
        {
            var allergy = await _allergyService.GetAllergy(IdAllergy);
            if (allergy == null) return NotFound();
            return Ok(allergy);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAllergys()
        {
            var allergies = await _allergyService.GetAllAllergys();
            return Ok(allergies);
        }

        [HttpPost]
        public async Task<IActionResult> AddAllergy(Allergy allergy)
        {
            await _allergyService.AddAllergy(allergy);
            return CreatedAtAction(nameof(GetAllergy), new { IdAllergy = allergy.IdAllergy }, allergy);
        }

        [HttpPut("{IdAllergy}")]
        public async Task<IActionResult> UpdateAllergy(int IdAllerdy, Allergy allergy)
        {
            if (IdAllerdy != allergy.IdAllergy) return BadRequest();
            await _allergyService.UpdateAllergy(allergy);
            return NoContent();
        }

        [HttpDelete("{IdAllergy}")]
        public async Task<IActionResult> DeleteAllergy(int IdAllergy)
        {
            await _allergyService.DeleteAllergy(IdAllergy);
            return Ok(new { message = "allergy delete whith success" });
        }
    }
}
