using Actividad7.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad7.Data
{
    public class Actividad7Context : DbContext
    {
        public DbSet<Enterprise> Enterprises { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public Actividad7Context(DbContextOptions<Actividad7Context> options) : base(options)
        {

        }
    }
}
