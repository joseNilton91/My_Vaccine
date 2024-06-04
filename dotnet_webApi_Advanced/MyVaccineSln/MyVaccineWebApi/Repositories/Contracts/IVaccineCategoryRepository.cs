using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Repositories.Contracts
{
    public interface IVaccineCategoryRepository
    {

        Task AddVaccineCategory(VaccineCategory vaccineCategory);

        Task<VaccineCategory> GetVaccineCategory(int vaccineCategory); 
        Task<List<VaccineCategory>> GetAllVaccineCategorys(); 

        Task UpdateVaccineCategory(VaccineCategory vaccineCategory); 

        Task DeleteVaccineCategory(int IdVaccineCategory); 
    }
}
