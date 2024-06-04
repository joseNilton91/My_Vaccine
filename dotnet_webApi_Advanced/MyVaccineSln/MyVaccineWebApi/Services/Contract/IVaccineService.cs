using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Services.Contract
{
    public interface IVaccineService
    {
        Task<Vaccine> GetVaccine(int IdVaccine);
        Task<List<Vaccine>> GetAllVaccines();
        Task AddVaccine(Vaccine vaccine);
        Task UpdateVaccine(Vaccine vaccine);
        Task DeleteVaccine(int IdVaccine);
    }
}
