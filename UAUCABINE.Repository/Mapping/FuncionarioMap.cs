using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAUCABINE.Domain.Entities;

namespace UAUCABINE.Repository.Mapping
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Idade)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(prop => prop.Cpf)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Sexo)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.HasOne(prop => prop.Cidade);
        }
    }
}
