using UAUCABINE.Domain.Entities;
using UAUCABINE.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using static UAUCABINE.Repository.Mapping.FestasMap;

namespace UAUCABINE.Repository.Context
{
    public sealed class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
            Database.EnsureCreated();
            ChangeTracker.LazyLoadingEnabled = false;

        }

        public DbSet<Funcionario>? Funcionario { get; set; }
        public DbSet<Cidade>? Cidade { get; set; }
        public DbSet<Festa>? Festa { get; set; }
        public DbSet<Equipamento>? Equipamentos { get; set; }
        public DbSet<FuncFesta>? FuncFesta { get; set; }
        public DbSet<EquipFesta>? EquipFesta { get; set; }
        public DbSet<Usuario>? Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Funcionario>(new FuncionarioMap().Configure);
            modelBuilder.Entity<Cidade>(new CidadeMap().Configure);
            modelBuilder.Entity<Festa>(new FestasMap().Configure);
            modelBuilder.Entity<Equipamento>(new EquipamentosMap().Configure);
            modelBuilder.Entity<FuncFesta>(new FuncFestaMap().Configure);
            modelBuilder.Entity<EquipFesta>(new EquiFestapMap().Configure);
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);

        }
    }
}
