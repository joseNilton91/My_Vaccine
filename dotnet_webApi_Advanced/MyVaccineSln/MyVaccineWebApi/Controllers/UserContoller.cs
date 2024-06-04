using Microsoft.AspNetCore.Mvc;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Services.Contract;

namespace MyVaccineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _userServices.GetUser(userId);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userServices.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            // Asegurarse de que las listas no sean nulas
            user.Dependents ??= new List<Dependent>();
            user.FamilyGroups ??= new List<FamilyGroup>();
            user.VaccineRecords ??= new List<VaccineRecord>();
            user.Allergies ??= new List<Allergy>();

            await _userServices.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { userId = user.UserId }, user);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, User user)
        {
            if (userId != user.UserId) return BadRequest();
            await _userServices.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userServices.DeleteUser(userId);
            return Ok(new { message = "user delete whith success" });
        }
    }
}


