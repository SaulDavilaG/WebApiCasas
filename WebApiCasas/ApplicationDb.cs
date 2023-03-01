using Microsoft.EntityFrameworkCore;
using WebApiCasas.Entidades;

namespace WebApiCasas
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Casa> Casas { get; set; }

    }
}
