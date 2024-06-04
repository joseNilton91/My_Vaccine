using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;
using MyVaccineWebApi.Services.Contract;

namespace MyVaccineWebApi.Services.Implements
{
    public class VaccineService : IVaccineService
    {
        private readonly MyVaccineAppDbContext _context;
        private readonly IVaccineRepository _vaccinerepository;

        public VaccineService(MyVaccineAppDbContext context, IVaccineRepository vaccineRepository)
        {
            _context = context;
            _vaccinerepository = vaccineRepository;
              
        }
        

        public  async Task AddVaccine(Vaccine vaccine)
        {
            var UpdatedAt = vaccine.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) vaccine.GetType().GetProperty("UpdatedAt").SetValue(vaccine, DateTime.UtcNow);

            var CreatedAt = vaccine.GetType().GetProperty("CreatedAt");
            if (CreatedAt != null) vaccine.GetType().GetProperty("CreatedAt").SetValue(vaccine, DateTime.UtcNow);

            await _context.AddAsync(vaccine);
            _context.Entry(vaccine).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Vaccine>> GetAllVaccines()
        {
            try
            {
                var vaccines = await _context.Vaccines.ToListAsync();
                return vaccines;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los usuarios.", ex);
            }
        }

        public async Task<Vaccine> GetVaccine(int IdVaccine)
        {
            try
            {
                // Busca el usuario por su ID
                var vaccine = await _context.Vaccines.FirstOrDefaultAsync(v => v.IdVaccine == IdVaccine);
                return vaccine;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario por ID.", ex);
            }
        }

        public  async Task UpdateVaccine(Vaccine vaccine)
        {
            var UpdatedAt = vaccine.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) vaccine.GetType().GetProperty("UpdatedAt").SetValue(vaccine, DateTime.UtcNow);
            _context.Update(vaccine);
            await _context.SaveChangesAsync();
        }
        public  async Task DeleteVaccine(int IdVaccine)
        {
            var vaccine = await GetVaccine(IdVaccine);
            if (vaccine != null)
            {
                _context.Vaccines.Remove(vaccine);
                await _context.SaveChangesAsync();
            }
        }
    }
}
