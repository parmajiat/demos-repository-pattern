using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Data
{
    public class MemoryRepository : IDataRepository
    {
        List<Employee> employees;
        public MemoryRepository()
        {
            employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Ahmad",
                    Country = "Syria",
                    PhoneNumber = "87542187",
                    PhotoPath="https://www.bitgab.com/uploads/profile/files/default.png",
                    BirthDate = new System.DateTime(1989, 3, 2),
                    HireDate = new System.DateTime(2010, 1, 1)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Khaled",
                    Country = "Egypt",
                    PhoneNumber = "69721054",
                    PhotoPath="https://www.bitgab.com/uploads/profile/files/default.png",
                    BirthDate = new System.DateTime(1988, 7, 6),
                    HireDate = new System.DateTime(2011, 1, 1)
                },
                new Employee
                {
                    Id = 3,
                    Name = "Omar",
                    Country = "Syria",
                    PhoneNumber = "248578700",
                    PhotoPath="https://www.bitgab.com/uploads/profile/files/default.png",
                    BirthDate = new System.DateTime(1992, 4, 4),
                    HireDate = new System.DateTime(2014, 1, 1)
                }
            };

        }
        public async Task<Employee> GetEmployee(int id)
        {
            await Task.Delay(0);
            var model = employees.FirstOrDefault(x => x.Id == id);
            return new Employee
            {
                Id = model.Id,
                Name = model.Name,
                Country = model.Country,
                BirthDate = model.BirthDate,
                HireDate = model.HireDate,
                PhoneNumber = model.PhoneNumber,
                PhotoPath = model.PhotoPath
            };
        }
        public async Task<List<Employee>> GetEmployees()
        {
            await Task.Delay(200);
            return employees;
        }
        public void SaveEmployee(Employee model)
        {
            if (model.Id == 0)
            {
                // Add
                employees.Add(model);
            }
            else
            {
                // Edit
                var entry = employees.FirstOrDefault(x => x.Id == model.Id);
                entry.Name = model.Name;
                entry.Country = model.Country;
                entry.PhoneNumber = model.PhoneNumber;
                entry.PhotoPath = model.PhotoPath;
                entry.BirthDate = model.BirthDate;
                entry.HireDate = model.HireDate;
            }
        }

        public void DeleteEmployee(int id)
        {
            Employee entry = employees.FirstOrDefault(x => x.Id == id);
            employees.Remove(entry);
        }
    }
}
