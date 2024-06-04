using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;
using MyVaccineWebApi.Services.Contract;

namespace MyVaccineWebApi.Services.Implements
{
    public class VaccineCategoryService : IVaccineCategoryService
    {
        private readonly IVaccineRecordRepository _repository;
        private readonly MyVaccineAppDbContext _context;

        public VaccineCategoryService(IVaccineRecordRepository repository, MyVaccineAppDbContext context)
        {
            repository = repository;
            _context = context;
        }
        public async Task AddVaccineCategory(VaccineCategory vaccineCategory)
        {
            var UpdatedAt = vaccineCategory.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) vaccineCategory.GetType().GetProperty("UpdatedAt").SetValue(vaccineCategory, DateTime.UtcNow);

            var CreatedAt = vaccineCategory.GetType().GetProperty("CreatedAt");
            if (CreatedAt != null) vaccineCategory.GetType().GetProperty("CreatedAt").SetValue(vaccineCategory, DateTime.UtcNow);

            await _context.AddAsync(vaccineCategory);
            _context.Entry(vaccineCategory).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task<List<VaccineCategory>> GetAllVaccineCategorys()
        {

            try
            {
                var vaccineCategories = await _context.VaccineCategories.ToListAsync();
                return vaccineCategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los usuarios.", ex);
            }
        }

        public async Task<VaccineCategory> GetVaccineCategory(int IdVaccineCategory)
        {
            try
            {
                // Busca el usuario por su ID
                var vaccineCategory = await _context.VaccineCategories.FirstOrDefaultAsync(vc => vc.IdVaccineCategory == IdVaccineCategory);
                return vaccineCategory;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario por ID.", ex);
            }
        }

        public Task UpdateVaccineCategory(VaccineCategory vaccineCategory)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteVaccineCategory(int IdVaccineCategory)
        {
            var vaccineCategory = await GetVaccineCategory(IdVaccineCategory);
            if (vaccineCategory != null)
            {
                _context.VaccineCategories.Remove(vaccineCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
