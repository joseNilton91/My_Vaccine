using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Services.Contract
{
    public interface IVaccineRecordService
    {
        Task<VaccineRecord> GetVaccineRecord(int IdVaccineRecord);
        Task<List<VaccineRecord>> GetAllVaccineRecords();
        Task AddVaccineRecord(VaccineRecord vaccineRecord);
        Task UpdateVaccineRecord(VaccineRecord vaccineRecord);
        Task DeleteVaccineRecord(int IdVaccineRecord);
    }
}
