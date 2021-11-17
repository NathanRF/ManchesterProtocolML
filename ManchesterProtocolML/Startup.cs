using FluentValidation;
using FluentValidation.AspNetCore;
using ManchesterProtocolML.Models;
using ManchesterProtocolML.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ManchesterProtocolML
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
            services.AddControllersWithViews()
                .AddFluentValidation(x =>
                {
                    x.DisableDataAnnotationsValidation = true;
                    x.ImplicitlyValidateChildProperties = true;

                    x.RegisterValidatorsFromAssemblyContaining<Paciente>();
                });

            //services.AddTransient<IValidator<Paciente>, PacienteValidator>();
            //services.AddTransient<IValidator<Prontuario>, ProntuarioValidator>();
            //services.AddTransient<IValidator<Sintoma>, SintomaValidator>();
            //services.AddTransient<IValidator<Situacao>, SituacaoValidator>();
            //services.AddTransient<IValidator<TipoSintoma>, TipoSintomaValidator>();
            //services.AddTransient<IValidator<Prioridade>, PrioridadeValidator>();
            //services.AddTransient<IValidator<Situacao>, SituacaoValidator>();
            //services.AddTransient<IValidator<Status>, StatusValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
