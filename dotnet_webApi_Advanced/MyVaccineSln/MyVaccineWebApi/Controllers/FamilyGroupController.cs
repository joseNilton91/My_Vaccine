using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Services.Contract;
using MyVaccineWebApi.Services.Implements;

namespace MyVaccineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyGroupController : ControllerBase
    {
        private readonly IFamilyGroupService _familyGroupService;

        public FamilyGroupController(IFamilyGroupService familyGroupService)
        {
            _familyGroupService = familyGroupService;
        }

        [HttpGet("{IdFamilyGroup}")]
        public async Task<IActionResult> GetFamilyGroup(int IdFamilyGroup)
        {
            var familyGroup = await _familyGroupService.GetFamilyGroup(IdFamilyGroup);
            if (familyGroup == null) return NotFound();
            return Ok(familyGroup);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFamilyGroups()
        {
            var familyGroup = await _familyGroupService.GetAllFamilyGroups();
            return Ok(familyGroup);
        }

        [HttpPost]
        public async Task<IActionResult> AddFamilyGroup(FamilyGroup familyGroup)
        {
            await _familyGroupService.AddFamilyGroup(familyGroup);
            return CreatedAtAction(nameof(GetFamilyGroup), new { IdFamilyGroup = familyGroup.IdFamilyGroup }, familyGroup);
        }

        [HttpPut("{IdFamilyGroup}")]
        public async Task<IActionResult> UpdateFamilyGroup(int IdFamilyGroup, FamilyGroup familyGroup)
        {
            if (IdFamilyGroup != familyGroup.IdFamilyGroup) return BadRequest();
            await _familyGroupService.UpdateFamilyGroup(familyGroup);
            return NoContent();
        }

        [HttpDelete("{IdFamilyGroup}")]
        public async Task<IActionResult> DeleteFamilyGroup(int IdFamilyGroup)
        {
            await _familyGroupService.DeleteFamilyGroup(IdFamilyGroup);
            return Ok(new { message = "familygroup delete whith success" });
        }
    }
}
