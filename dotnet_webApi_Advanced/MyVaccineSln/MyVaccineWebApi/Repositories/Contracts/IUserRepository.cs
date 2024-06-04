using Microsoft.AspNetCore.Identity;
using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Repositories.Contracts
{
    public interface IUserRepository: IBaseRepository
    {
        Task<IdentityResult> AddUser(User user );
    }
}
