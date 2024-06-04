using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Repositories.Contracts
{
    public interface IVaccineRecordRepository
    {
        Task<VaccineRecord> GetVaccineRecord(int IdVaccineRecord);
        Task<List<VaccineRecord>> GetAllVaccineRecords();
        Task AddVaccineRecord(VaccineRecord vaccineRecord);
        Task UpdateVaccineRecord(VaccineRecord vaccineRecord);
        Task DeleteVaccineRecord(int IdVaccineRecord);
    }
}
