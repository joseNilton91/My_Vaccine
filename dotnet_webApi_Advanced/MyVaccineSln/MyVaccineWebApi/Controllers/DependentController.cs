using Microsoft.AspNetCore.Mvc;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Services.Contract;
using MyVaccineWebApi.Services.Implements;

namespace MyVaccineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentController: ControllerBase
    {
        public readonly IDependentService dependentService;

        public DependentController(IDependentService dependentService)
        {
            this.dependentService = dependentService;
        }

        [HttpGet("{IdDependent}")]
        public async Task<IActionResult> GetDependent(int IdDependent)
        {
            var dependent = await dependentService.GetDependent(IdDependent);
            if (dependent == null) return NotFound();
            return Ok(dependent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepenedents()
        {
            var dependents = await dependentService.GetAllDependents();
            return Ok(dependents);
        }

        [HttpPost]
        public async Task<IActionResult> AddDependent(Dependent dependent)
        {
            dependent.VaccineRecords ??= new List<VaccineRecord>();
            await dependentService.AddDependent(dependent);
            return CreatedAtAction(nameof(GetDependent), new { IdDependent = dependent.IdDependent }, dependent);
        }


        [HttpPut("{IdDependent}")]
        public async Task<IActionResult> UpdateDependent(int IdDependent, Dependent dependent)
        {
            if (IdDependent != dependent.IdDependent) return BadRequest();
            await dependentService.UpdateDependent(dependent);
            return NoContent();
        }

        [HttpDelete("{IdDependent}")]
        public async Task<IActionResult> DeleteDependent(int IdDependent)
        {
            await dependentService.DeleteDependent(IdDependent);
            return Ok(new { message = "dependent delete whith success" });
        }
    }
}
