using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Repositories.Contracts
{
    public interface IFamilyGroupRepository
    {
        Task<FamilyGroup> GetFamilyGroup(int IdFamilyGroup);
        Task<List<FamilyGroup>> GetAllFamilyGroups();
        Task AddFamilyGroup(FamilyGroup familyGroup);
        Task UpdateFamilyGroup(FamilyGroup familyGroup);
        Task DeleteFamilyGroup(int IdFamilyGroup);
    }
}
