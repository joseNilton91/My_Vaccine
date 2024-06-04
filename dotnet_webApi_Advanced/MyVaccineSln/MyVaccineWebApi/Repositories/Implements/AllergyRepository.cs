using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;
using System.Reflection.PortableExecutable;

namespace MyVaccineWebApi.Repositories.Implements
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public AllergyRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }
        public  async Task AddAllergy(Allergy allergy)
        {
            var UpdatedAt = allergy.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) allergy.GetType().GetProperty("UpdatedAt").SetValue(allergy, DateTime.UtcNow);
            var CreatedAt = allergy.GetType().GetProperty("CreatedAt");
            if (CreatedAt != null) allergy.GetType().GetProperty("CreatedAt").SetValue(allergy, DateTime.UtcNow);

            await _context.AddAsync(allergy);
            _context.Entry(allergy).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public  async Task<List<Allergy>> GetAllAllergys()
        {
            try
            {
                var allergies = await _context.Allergies.ToListAsync();
                return allergies;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los usuarios.", ex);
            }
        }

        public async Task<Allergy> GetAllergy(int IdAllergy)
        {
            try
            {
                // Busca el usuario por su ID
                var allergy = await _context.Allergies.FirstOrDefaultAsync(a => a.IdAllergy == IdAllergy);
                return allergy;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario por ID.", ex);
            }
        }

        public async Task UpdateAllergy(Allergy allergy)
        {
            var UpdatedAt = allergy.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) allergy.GetType().GetProperty("UpdatedAt").SetValue(allergy, DateTime.UtcNow);
            _context.Update(allergy);
            await _context.SaveChangesAsync();
        }
        public  async Task DeleteAllergy(int IdAllergy)
        {
            var allergy = await GetAllergy(IdAllergy);
            if (allergy != null)
            {
                _context.Allergies.Remove(allergy);
                await _context.SaveChangesAsync();
            }
        }
    }
}
