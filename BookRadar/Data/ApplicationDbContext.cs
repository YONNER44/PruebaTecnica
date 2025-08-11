using Microsoft.EntityFrameworkCore;
using BookRadar.Models;

namespace BookRadar.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SearchHistory> HistorialBusquedas { get; set; }
    }
}
