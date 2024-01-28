using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TributoJusto.Business.Models;

namespace TributoJusto.Data.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnType("DECIMAL");

            builder.Property(x => x.CurrencyCode)
                .IsRequired()
                .HasColumnType("NVARCHAR(10)");

            builder.Property(x => x.Saleability)
                .IsRequired()
                .HasColumnType("NVARCHAR(20)");

            builder.Property(x => x.Country)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.CountrySale)
                .IsRequired()
                .HasColumnType("NVARCHAR(250)");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR(100)");

            builder.Property(x => x.Authors)
                .IsRequired()
                .HasColumnType("NVARCHAR(150)");

            builder.Property(x => x.Categories)
                .IsRequired()
                .HasColumnType("NVARCHAR(100)");

            builder.Property(x => x.Publisher)
                .IsRequired()
                .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.PageCount)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("NVARCHAR(MAX)");

            builder.HasMany(x => x.Favoritos)
                .WithOne(z => z.Livro)
                .HasForeignKey(k => k.LivroId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Livros");
        }
    }
}
