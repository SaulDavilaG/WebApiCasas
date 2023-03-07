using Microsoft.EntityFrameworkCore;
using WebApiCasas.Entidades;

namespace WebApiCasas.Controllers
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Casa> Casas { get; set; }
        public DbSet<Habitante> Habitante { get; set;}
    }
}
