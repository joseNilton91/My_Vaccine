using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Services.Contract
{
    public interface IAllergyService
    {
        Task<Allergy> GetAllergy(int IdAllergy);
        Task<List<Allergy>> GetAllAllergys();
        Task AddAllergy(Allergy allergy);
        Task UpdateAllergy(Allergy allergy);
        Task DeleteAllergy(int IdAllergy);
    }
}
