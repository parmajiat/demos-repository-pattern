using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Data
{
    public interface IDataRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);        
        void SaveEmployee(Employee model);
        void DeleteEmployee(int id);
    }
}
