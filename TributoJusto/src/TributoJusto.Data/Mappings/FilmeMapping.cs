using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TributoJusto.Business.Models;

namespace TributoJusto.Data.Mappings
{
    public class FilmeMapping : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Writer)
                .IsRequired()
                .HasColumnType("NVARCHAR(250)");

            builder.Property(x => x.Plot)
                .IsRequired()
                .HasColumnType("NVARCHAR(500)");

            builder.Property(x => x.Year)
                .IsRequired()
                .HasColumnType("VARCHAR(4)");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Actors)
                .IsRequired()
                .HasColumnType("NVARCHAR(250)");

            builder.Property(x => x.Genre)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Director)
                .IsRequired()
                .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.Country)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.ImdbRating)
                .IsRequired()
                .HasColumnType("VARCHAR(4)");

            builder.HasMany(x => x.Favoritos)
                .WithOne(z => z.Filme)
                .HasForeignKey(k => k.FilmeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Filmes");
        }
    }
}
