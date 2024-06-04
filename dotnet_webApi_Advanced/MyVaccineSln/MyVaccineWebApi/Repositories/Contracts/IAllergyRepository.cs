using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Repositories.Contracts
{
    public interface IAllergyRepository
    {
        Task<Allergy> GetAllergy(int IdAllergy);
        Task<List<Allergy>> GetAllAllergys();
        Task AddAllergy(Allergy allergy);
        Task UpdateAllergy(Allergy allergy);
        Task DeleteAllergy(int IdAllergy);
    }
}
