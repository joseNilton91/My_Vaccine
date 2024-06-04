using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;
using MyVaccineWebApi.Services.Contract;

namespace MyVaccineWebApi.Services.Implements
{

    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly MyVaccineAppDbContext _context;

        public UserServices(IUserRepository userRepository, MyVaccineAppDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task AddUser(User user)
        {
            try
            {
                // Agrega el usuario a la base de datos
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario.", ex);
            }
        }



        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                // Consulta todos los usuarios desde la base de datos
                var users = await _context.Users.ToListAsync();

                // Actualiza las propiedades CreatedAt y UpdatedAt
                foreach (var user in users)
                {
                    if (user.GetType().GetProperty("UpdatedAt") != null)
                        user.GetType().GetProperty("UpdatedAt").SetValue(user, DateTime.UtcNow);

                    if (user.GetType().GetProperty("CreatedAt") != null)
                        user.GetType().GetProperty("CreatedAt").SetValue(user, DateTime.UtcNow);
                }

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();

                return users;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción (por ejemplo, conexión a la base de datos, etc.)
                // Aquí puedes registrar o manejar el error según tus necesidades
                throw new Exception("Error al obtener todos los usuarios.", ex);
            }
        }


        public async Task<User> GetUser(int userId)
        {
            {
                try
                {
                    // Busca el usuario por su ID
                    var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                    return user;
                }

                catch (Exception ex)
                {
                    throw new Exception("Error al buscar el usuario por ID.", ex);
                }
            }
        }

        public async Task UpdateUser(User user)
        {
            {
                var UpdatedAt = user.GetType().GetProperty("UpdatedAt");
                if (UpdatedAt != null) user.GetType().GetProperty("UpdatedAt").SetValue(user, DateTime.UtcNow);

                _context.Update(user);
                await _context.SaveChangesAsync();
            }

        }
        public async Task DeleteUser(int userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine($"Usuario con ID {userId} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario.", ex);
            }
        }
    }
}