using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Services.Contract
{
    public interface IFamilyGroupService
    {
        Task<FamilyGroup> GetFamilyGroup(int IdFamilyGroup);
        Task<List<FamilyGroup>> GetAllFamilyGroups();
        Task AddFamilyGroup(FamilyGroup familyGroup);
        Task UpdateFamilyGroup(FamilyGroup familyGroup);
        Task DeleteFamilyGroup(int IdFamilyGroup);
    }
}
