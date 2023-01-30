using CrudApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmployeeMaster> employees { get; set; }
    }
}
