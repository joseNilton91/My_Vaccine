using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;

namespace MyVaccineWebApi.Repositories.Implements
{
    public class BaseRepository : IBaseRepository
    {

        public readonly MyVaccineAppDbContext _context;

        public BaseRepository(MyVaccineAppDbContext context) {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            var UpdatedAt = user.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) user.GetType().GetProperty("UpdatedAt").SetValue(user, DateTime.UtcNow);

            var CreatedAt = user.GetType().GetProperty("CreatedAt");
            if (CreatedAt != null) user.GetType().GetProperty("CreatedAt").SetValue(user, DateTime.UtcNow);

            await _context.AddAsync(user);
            _context.Entry(user).State = EntityState.Added;
            await _context.SaveChangesAsync();
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

        public async Task UpdateUser(User user)
        {
              var UpdatedAt = user.GetType().GetProperty("UpdatedAt");
              if (UpdatedAt != null) user.GetType().GetProperty("UpdatedAt").SetValue(user, DateTime.UtcNow);
                _context.Update(user);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteUser(int userId)
        {
            _context.Remove(userId);
            await _context.SaveChangesAsync();
        }
    }
}

    
