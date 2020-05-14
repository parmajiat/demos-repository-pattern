using RepositoryPattern.Models;
using System.Data.Entity;
namespace RepositoryPattern.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext") { }

        public virtual DbSet<Employee> Employees { get; set; }                
    }
}
