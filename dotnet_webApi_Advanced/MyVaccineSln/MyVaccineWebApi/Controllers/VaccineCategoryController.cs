using Microsoft.AspNetCore.Mvc;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Services.Contract;

namespace MyVaccineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineCategoryController : ControllerBase
    {
        private readonly  IVaccineCategoryService _vaccineCategoryService;

        public VaccineCategoryController(IVaccineCategoryService vaccineCategoryService)
        {
            _vaccineCategoryService = vaccineCategoryService;
        }

        [HttpGet("{IdVaccineCategory}")]
        public async Task<IActionResult> GetVaccineCategory(int IdVaccineCategory)
        {
            var vaccineCategory = await _vaccineCategoryService.GetVaccineCategory(IdVaccineCategory);
            if (vaccineCategory == null) return NotFound();
            return Ok(vaccineCategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVaccineCategorys()
        {
            var users = await _vaccineCategoryService.GetAllVaccineCategorys();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddVaccineCategory(VaccineCategory vaccineCategory)
        {
            // Asegurarse de que las listas no sean nulas
           
            vaccineCategory.Vaccines ??= new List<Vaccine>();

            await _vaccineCategoryService.AddVaccineCategory(vaccineCategory);
            return CreatedAtAction(nameof(GetVaccineCategory), new { IdVaccineCategory = vaccineCategory.IdVaccineCategory }, vaccineCategory);
        }

        [HttpPut("{IdVaccineCategory}")]
        public async Task<IActionResult> UpdateVaccineCategory(int IdVaccineCategory, VaccineCategory vaccineCategory)
        {
            if (IdVaccineCategory != vaccineCategory.IdVaccineCategory) return BadRequest();
            await _vaccineCategoryService.UpdateVaccineCategory(vaccineCategory);
            return NoContent();
        }

        [HttpDelete("{IdVaccineCategory}")]
        public async Task<IActionResult> DeleteVaccineCategory(int IdVaccineCategory)
        {
            await _vaccineCategoryService.DeleteVaccineCategory(IdVaccineCategory);
            return Ok(new { message = "vaccinecategory delete whith success" });
        }
    }
}

