using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Services.Contract
{
    public interface IVaccineCategoryService
    {

        Task<VaccineCategory> GetVaccineCategory(int IdVaccineCategory);
        Task<List<VaccineCategory>> GetAllVaccineCategorys();
        Task AddVaccineCategory(VaccineCategory vaccineCategory);
        Task UpdateVaccineCategory(VaccineCategory vaccineCategory);
        Task DeleteVaccineCategory(int IdVaccineCategory);
    }
}
