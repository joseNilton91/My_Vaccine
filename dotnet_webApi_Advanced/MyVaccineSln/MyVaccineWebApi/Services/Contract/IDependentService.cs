using MyVaccineWebApi.Models;

namespace MyVaccineWebApi.Services.Contract
{
    public interface IDependentService
    {

        Task AddDependent(Dependent dependent); // agregar una dependencia

        Task<Dependent> GetDependent(int dependenId); // buscar una dependencia

        Task<List<Dependent>> GetAllDependents(); // listar las dependnecias

        Task UpdateDependent(Dependent dependent); // actualizar una dependencia

        Task DeleteDependent(int dependentId); // eliminar una dependencia.
    }
}
