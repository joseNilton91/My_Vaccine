using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;
namespace MyVaccineWebApi.Repositories.Implements
{
    public class DependentRepository : IDependentRepository
    {
        private readonly MyVaccineAppDbContext _context;
        public DependentRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }
        public async Task AddDependent(Dependent dependent)
        {
            var UpdatedAt = dependent.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) dependent.GetType().GetProperty("UpdatedAt").SetValue(dependent, DateTime.UtcNow);

            var CreatedAt = dependent.GetType().GetProperty("CreatedAt");
            if (CreatedAt != null) dependent.GetType().GetProperty("CreatedAt").SetValue(dependent, DateTime.UtcNow);

            await _context.AddAsync(dependent);
            _context.Entry(dependent).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task<Dependent> GetDependent(int dependentId)
        {
            try
            {
                // Busca el usuario por su ID
                var dependent = await _context.Dependents.FirstOrDefaultAsync(d => d.IdDependent == dependentId);
                return dependent;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario por ID.", ex);
            }

        }
        public async Task<List<Dependent>> GetAllDependents()
        {
            try
            {
                var dependents = await _context.Dependents.ToListAsync();
                return dependents;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los usuarios.", ex);
            }
        }
        public async Task UpdateDependent(Dependent dependent)
        {
            var UpdatedAt = dependent.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) dependent.GetType().GetProperty("UpdatedAt").SetValue(dependent, DateTime.UtcNow);

            _context.Update(dependent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDependent(int dependentId)
        {
            var dependent = await GetDependent(dependentId);
            if (dependent != null)
            {
                _context.Dependents.Remove(dependent);
                await _context.SaveChangesAsync();
            }
        }
    }
}