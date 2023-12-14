using UAUCABINE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UAUCABINE.Repository.Mapping
{
    public class FestasMap : IEntityTypeConfiguration<Festa>
    {
        public void Configure(EntityTypeBuilder<Festa> builder)
        {
            builder.ToTable("Festas");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.NomeSalao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Rua)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Numero)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(prop => prop.HoraIni)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(prop => prop.HoraFim)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasOne(prop => prop.Cidade);

            builder.HasMany(prop => prop.Funcio)
                .WithOne(prop => prop.Festa)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(prop => prop.Equipa)
                .WithOne(prop => prop.Festa)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public class FuncFestaMap : IEntityTypeConfiguration<FuncFesta>
        {
            public void Configure(EntityTypeBuilder<FuncFesta> builder)
            {
                builder.ToTable("FuncionarioFesta");

                builder.HasKey(prop => prop.Id);

                builder.HasOne(prop => prop.Festa)
                    .WithMany(prop => prop.Funcio)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }

        public class EquiFestapMap : IEntityTypeConfiguration<EquipFesta>
        {
            public void Configure(EntityTypeBuilder<EquipFesta> builder)
            {
                builder.ToTable("EquipamentoFesta");

                builder.HasKey(prop => prop.Id);

                builder.HasOne(prop => prop.Festa)
                    .WithMany(prop => prop.Equipa)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
}
