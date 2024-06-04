using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;

namespace MyVaccineWebApi.Repositories.Implements
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public UserRepository(MyVaccineAppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IdentityResult> AddUser(User user)
        {
            try
            {
                // Agrega el usuario a la base de datos
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                // Devuelve el resultado (puede ser IdentityResult.Success o contener errores)
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario.", ex);
            }
        }
    }
}