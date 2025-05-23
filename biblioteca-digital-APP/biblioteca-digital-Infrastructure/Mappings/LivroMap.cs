using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using biblioteca_digital_DOMAIN.Entities;

namespace biblioteca_digital_Infrastructure.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");

            builder.HasKey(l => l.Id);
           
            builder.Property(l => l.Id)
                .ValueGeneratedNever();

            builder.Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(l => l.Autor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.Ano)
                .IsRequired();

            builder.Property(l => l.Genero)
                .IsRequired()
                .HasMaxLength(100);
        }
    }


}
