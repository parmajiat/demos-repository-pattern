using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Repository
{
    public class EFRepository : IDataRepository
    {
        readonly DataContext db = new DataContext();
        public async Task<List<Employee>> GetEmployees()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var model = await db.Employees.FindAsync(id);
            return model;
        }
        public void SaveEmployee(Employee model)
        {
            if (model.Id == 0)
            {
                // Add
                db.Employees.Add(model);
            }
            else
            {
                // Edit
                var entry = db.Employees.FirstOrDefault(x => x.Id == model.Id);
                entry.Name = model.Name;
                entry.Country = model.Country;
                entry.PhoneNumber = model.PhoneNumber;
                entry.PhotoPath = model.PhotoPath;
                entry.BirthDate = model.BirthDate;
                entry.HireDate = model.HireDate;
            }
            db.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            Employee entry = db.Employees.FirstOrDefault(x => x.Id == id);
            db.Employees.Remove(entry);
            db.SaveChanges();
        }
    }
}
