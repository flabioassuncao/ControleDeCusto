
using AutoMapper;
using ControleDeCustos.Application.Interfaces;
using ControleDeCustos.Application.Services;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Infra.Data.Context;
using ControleDeCustos.Infra.Data.Repository;
using ControleDeCustos.Infra.Data.UoW;
using ControleDeCustos.Infra.Identity.Models;
using ControleDeCustos.Infra.Identity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ControleDeCustos.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IDepartamentoAppService, DepartamentoAppService>();
            services.AddScoped<IMovimentacaoAppService, MovimentacaoAppService>();
            services.AddScoped<IFuncionarioAppService, FuncionarioAppService>();


            // Infra - Data
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CDCContext>();
            
            // Infra - Identity
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
