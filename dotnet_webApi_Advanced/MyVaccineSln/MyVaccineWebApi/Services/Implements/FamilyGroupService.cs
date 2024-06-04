using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;
using MyVaccineWebApi.Services.Contract;

namespace MyVaccineWebApi.Services.Implements
{
    public class FamilyGroupService : IFamilyGroupService
    {
        private readonly IFamilyGroupRepository _familyrepository;
        private readonly MyVaccineAppDbContext _context;

        public FamilyGroupService(IFamilyGroupRepository familyrepository, MyVaccineAppDbContext context)
        {
            _familyrepository = familyrepository;
            _context = context;
        }
        public async Task AddFamilyGroup(FamilyGroup familyGroup)
        {
            var UpdatedAt = familyGroup.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) familyGroup.GetType().GetProperty("UpdatedAt").SetValue(familyGroup, DateTime.UtcNow);
            var CreatedAt = familyGroup.GetType().GetProperty("CreatedAt");
            if (CreatedAt != null) familyGroup.GetType().GetProperty("CreatedAt").SetValue(familyGroup, DateTime.UtcNow);

            await _context.AddAsync(familyGroup);
            _context.Entry(familyGroup).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<List<FamilyGroup>> GetAllFamilyGroups()
        {
            try
            {
                var familygroups = await _context.FamilyGroups.ToListAsync();
                return familygroups;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los usuarios.", ex);
            }
        }

        public async Task<FamilyGroup> GetFamilyGroup(int IdFamilyGroup)
        {
            try
            {
                // Busca el usuario por su ID
                var familyGroups = await _context.FamilyGroups.FirstOrDefaultAsync(fg => fg.IdFamilyGroup == IdFamilyGroup);
                return familyGroups;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario por ID.", ex);
            }
        }

        public async Task UpdateFamilyGroup(FamilyGroup familyGroup)
        {
            var UpdatedAt = familyGroup.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) familyGroup.GetType().GetProperty("UpdatedAt").SetValue(familyGroup, DateTime.UtcNow);
            _context.Update(familyGroup);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFamilyGroup(int IdFamilyGroup)
        {
            var familyGroup = await GetFamilyGroup(IdFamilyGroup);
            if (familyGroup != null)
            {
                _context.FamilyGroups.Remove(familyGroup);
                await _context.SaveChangesAsync();
            }
        }
    }
}
