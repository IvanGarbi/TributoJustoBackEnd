using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using TributoJusto.Business.Models;

namespace TributoJusto.Data.Context
{
    public class TributoJustoDbContext : DbContext
    {
        public TributoJustoDbContext(DbContextOptions<TributoJustoDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetProperties()
                             .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("VARCHAR(250)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TributoJustoDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
