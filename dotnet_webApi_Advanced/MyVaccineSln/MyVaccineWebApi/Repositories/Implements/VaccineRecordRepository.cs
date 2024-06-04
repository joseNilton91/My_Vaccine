using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Models;
using MyVaccineWebApi.Repositories.Contracts;

namespace MyVaccineWebApi.Repositories.Implements
{
    public class VaccineRecordRepository : IVaccineRecordRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public VaccineRecordRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }
      
        public async Task AddVaccineRecord(VaccineRecord vaccineRecord)
        {
            var UpdatedAt = vaccineRecord.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) vaccineRecord.GetType().GetProperty("UpdatedAt").SetValue(vaccineRecord, DateTime.UtcNow);
            var CreatedAt = vaccineRecord.GetType().GetProperty("CreatedAt");
            if (CreatedAt != null) vaccineRecord.GetType().GetProperty("CreatedAt").SetValue(vaccineRecord, DateTime.UtcNow);

            await _context.AddAsync(vaccineRecord);
            _context.Entry(vaccineRecord).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }


        public async Task<VaccineRecord> GetVaccineRecord(int IdVaccineRecord)
        {
            try
            {
                // Busca el usuario por su ID
                var vaccineRecords = await _context.VaccineRecords.FirstOrDefaultAsync(vr => vr.IdVaccineRecord == IdVaccineRecord);
                return vaccineRecords;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario por ID.", ex);
            }
        }

        public async Task<List<VaccineRecord>> GetAllVaccineRecords()
        {

            try
            {
                var vaccineRecords = await _context.VaccineRecords.ToListAsync();
                return vaccineRecords;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los usuarios.", ex);
            }
        }

        public async Task UpdateVaccineRecord(VaccineRecord vaccineRecord)
        {
            var UpdatedAt = vaccineRecord.GetType().GetProperty("UpdatedAt");
            if (UpdatedAt != null) vaccineRecord.GetType().GetProperty("UpdatedAt").SetValue(vaccineRecord, DateTime.UtcNow);
            _context.Update(vaccineRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVaccineRecord(int IdVaccineRecord)
        {
            var vacccineRecord = await GetVaccineRecord(IdVaccineRecord);
            if (vacccineRecord != null)
            {
                _context.VaccineRecords.Remove(vacccineRecord);
                await _context.SaveChangesAsync();
            }
        }

    }
}