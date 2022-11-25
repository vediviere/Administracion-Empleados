using AdministracionEmpleadosApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdministracionEmpleadosApi
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Beneficiario> Beneficiarios { get; set; }
    }
}
