using MyVaccineWebApi.Models;
using System.Runtime.CompilerServices;

namespace MyVaccineWebApi.Repositories.Contracts
{
    public interface IDependentRepository
    {
        Task AddDependent(Dependent dependent); // agregar una dependencia

        Task<Dependent> GetDependent(int dependenId); // buscar una dependencia

        Task<List<Dependent>> GetAllDependents(); // listar las dependnecias

        Task UpdateDependent(Dependent dependent); // actualizar una dependencia

        Task DeleteDependent(int dependentId); // eliminar una dependencia.
    }
}
