using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Services.Contract
{
    public interface IUserServices
    {
        Task<User> GetUser(int userId);
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
    }
}
