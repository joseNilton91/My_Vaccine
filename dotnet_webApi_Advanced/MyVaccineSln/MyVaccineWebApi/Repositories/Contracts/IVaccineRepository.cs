using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Repositories.Contracts
{
    public interface IVaccineRepository
    {
        Task AddVaccine(Vaccine vaccine);

        Task<Vaccine> GetVaccine(int IdVaccine);
        Task<List<Vaccine>> GetAllVaccines();

        Task UpdateVaccine(Vaccine vaccine);

        Task DeleteVaccine(int IdVaccine);
    }
}
