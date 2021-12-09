using LivroShop.Configuracao;
using LivroShop.Controllers;
using LivroShop.Dados.Contexto;
using LivroShop.Dados.Repositorio;
using LivroShop.Dados.Repositorio.Interfaces;
using LivroShop.Services.Auth.Jwt;
using LivroShop.Services.Auth.Jwt.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivroShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Autenticacao
            services.AddConfiguracaoAuth(Configuration);

            //Configurações
            var sessao = Configuration.GetSection("JwtConfiguracoes");
            services.Configure<JwtConfiguracoes>(sessao);

            // Repositórios
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            //Serviços
            services.AddScoped<IJwtAuthGerenciador, JwtAuthGerenciador>();
            
            // Controllers
            services.AddControllers();

            //Swagger - Documentação Api's
            services.AdicionarConfiguracaoSwagger();

            //Contextos
            services.AddDbContext<LivrosBDcontexto>(options => options.UseInMemoryDatabase(databaseName: "LivroBD"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseConfiguracaoSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
