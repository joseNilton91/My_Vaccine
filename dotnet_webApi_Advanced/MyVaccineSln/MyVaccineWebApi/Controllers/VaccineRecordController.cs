using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Services.Contract;
using MyVaccineWebApi.Services.Implements;

namespace MyVaccineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineRecordController : ControllerBase
    {
        private readonly IVaccineRecordService _vaccineRecordServices;

        public VaccineRecordController(IVaccineRecordService vaccineRecordServices)
        {

            _vaccineRecordServices = vaccineRecordServices;
        }


        [HttpGet("{IdVaccineRecord}")]
        public async Task<IActionResult> GetVaccineRecord(int IdVaccineRecord)
        {
            var vaccineRecord = await _vaccineRecordServices.GetVaccineRecord(IdVaccineRecord);
            if (vaccineRecord == null) return NotFound();
            return Ok(vaccineRecord);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVaccineRecords()
        {
            var vaccineRecord = await _vaccineRecordServices.GetAllVaccineRecords();
            return Ok(vaccineRecord);
        }

        [HttpPost]
        public async Task<IActionResult> AddVaccineRecord(VaccineRecord vaccineRecord)
        {
            await _vaccineRecordServices.AddVaccineRecord(vaccineRecord);
            return CreatedAtAction(nameof(GetVaccineRecord), new { IdVaccineRecord = vaccineRecord.IdVaccineRecord }, vaccineRecord);
        }

        [HttpPut("{IdVaccineRecord}")]
        public async Task<IActionResult> UpdateVaccineRecord(int IdVaccineRecord, VaccineRecord vaccineRecord)
        {
            if (IdVaccineRecord != vaccineRecord.IdVaccineRecord) return BadRequest();
            await _vaccineRecordServices.UpdateVaccineRecord(vaccineRecord);
            return NoContent();
        }

        [HttpDelete("{IdVaccineRecor}")]
        public async Task<IActionResult> DeleteVaccineRecord(int IdVaccineRecord)
        {
            await _vaccineRecordServices.DeleteVaccineRecord(IdVaccineRecord);
            return Ok(new { message = "vaccinerecord delete whith success" });
        }
    }
}

    

    
