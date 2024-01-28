using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TributoJusto.Business.Models;

namespace TributoJusto.Data.Mappings
{
    public class FavoritoMapping : IEntityTypeConfiguration<Favorito>
    {
        public void Configure(EntityTypeBuilder<Favorito> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.LivroId)
                   .IsRequired(false)
                   .HasColumnType("UNIQUEIDENTIFIER");

            builder.Property(x => x.FilmeId)
                   .IsRequired(false)
                   .HasColumnType("UNIQUEIDENTIFIER");

            builder.Property(x => x.UsuarioId)
                   .IsRequired()
                   .HasColumnType("UNIQUEIDENTIFIER");

            builder.ToTable("Favoritos");
        }
    }
}
