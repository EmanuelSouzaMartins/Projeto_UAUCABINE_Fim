using AutoMapper;
using UAUCABINE.App.Cadastros;
using UAUCABINE.App.Models;
using UAUCABINE.App.Outros;
using UAUCABINE.Domain.Base;
using UAUCABINE.Domain.Entities;
using UAUCABINE.Repository.Context;
using UAUCABINE.Repository.Repository;
using UAUCABINE.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.Logging;
using UAUCABINE.App.Outros;

namespace UAUCABINE.App.Infra
{
    public static class ConfigureDI
    {
        public static ServiceCollection? Services;

        public static ServiceProvider? ServicesProvider;

        public static void ConfiguraServices() 
        {
            Services = new ServiceCollection();
            var strCon = File.ReadAllText("../../../Config/DatabaseSettings.txt");
            Services.AddDbContext<MySqlContext>(options =>
            {
                options.LogTo(Console.WriteLine)
                    .EnableSensitiveDataLogging();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging();


                options.UseMySql(strCon, ServerVersion.AutoDetect(strCon), opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

            Services.AddScoped<IBaseRepository<Funcionario>, BaseRepository<Funcionario>>();
            Services.AddScoped<IBaseRepository<Cidade>, BaseRepository<Cidade>>();
            Services.AddScoped<IBaseRepository<Equipamento>, BaseRepository<Equipamento>>();
            Services.AddScoped<IBaseRepository<Festa>, BaseRepository<Festa>>();
            Services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
            Services.AddScoped<IBaseRepository<FuncFesta>, BaseRepository<FuncFesta>>();
            Services.AddScoped<IBaseRepository<EquipFesta>, BaseRepository<EquipFesta>>();

            Services.AddScoped<IBaseService<Funcionario>, BaseService<Funcionario>>();
            Services.AddScoped<IBaseService<Cidade>, BaseService<Cidade>>();
            Services.AddScoped<IBaseService<Equipamento>, BaseService<Equipamento>>();
            Services.AddScoped<IBaseService<Festa>, BaseService<Festa>>();
            Services.AddScoped<IBaseService<Usuario>, BaseService<Usuario>>();
            Services.AddScoped<IBaseService<FuncFesta>, BaseService<FuncFesta>>();
            Services.AddScoped<IBaseService<EquipFesta>, BaseService<EquipFesta>>();


            Services.AddTransient<Login, Login>();
            Services.AddTransient<CadastroFuncionario, CadastroFuncionario>();
            Services.AddTransient<CadastroEquipamentos, CadastroEquipamentos>();
            Services.AddTransient<CadastroFesta, CadastroFesta>();
            Services.AddTransient<CadastroCidade, CadastroCidade>();
            Services.AddTransient<VisualizarFestas, VisualizarFestas>();
            Services.AddTransient<FuncioEquip, FuncioEquip>();

            Services.AddSingleton(new MapperConfiguration(config =>
            {

                config.CreateMap<Usuario, UsuarioModel>();
                config.CreateMap<Cidade, CidadeModel>();
                //.ForMember(d => d.NomeEstado, d => d.MapFrom(x => $"{x.Nome}/{x.Estado}"));
                config.CreateMap<Funcionario, FuncionariosModel>()
                    .ForMember(d => d.NomeCidade, d => d.MapFrom(x => $"{x.Cidade!.Nome}"))
                    .ForMember(d => d.IdCidade, d => d.MapFrom(x => x.Cidade!.Id));
                    //.ForMember(d => d.IdFunc, d => d.MapFrom(x => x.Id))
                    //.ForMember(d => d.NomeFunc, d => d.MapFrom(x => x.Nome));
                config.CreateMap<Equipamento, EquipamentosModel>();
                config.CreateMap<Festa, FestaModel>()
                    .ForMember(d => d.Cidade, d => d.MapFrom(x => $"{x.Cidade!.Nome}"))
                    .ForMember(d => d.IdCidade, d => d.MapFrom(x => x.Cidade!.Id));

                //.ForMember(d => d.IdFuncio, d => d.MapFrom(x => x.Funcio!.))
                //.ForMember(d => d.IdEquip, d => d.MapFrom(x => x.Equipa!.Id));
                config.CreateMap<FuncFesta, FuncFestas>()
                    .ForMember(d => d.NomeFuncio, d => d.MapFrom(x => $"{x.Funcionario!.Nome}"));
                config.CreateMap<EquipFesta, EquiFesta>()
                    .ForMember(d => d.NomeEquip, d => d.MapFrom(x => $"{x.Equipamentos!.Nome}"));


            }).CreateMapper());

            ServicesProvider = Services.BuildServiceProvider();
        }
    }
}
