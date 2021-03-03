using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Tasinmaz.Entities;
using Tasinmaz.Contracts;
using Tasinmaz.Services;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Cors;
using System.Threading.Tasks;

namespace Tasinmaz
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
            services.AddSingleton<IKullaniciRepository, KullaniciService>();
            services.AddSingleton<IIlRepository, IlService>();
            services.AddSingleton<IIlceRepository, IlceService>();
            services.AddSingleton<IMahalleRepositoryy, MahalleService>();
            services.AddSingleton<ITasinmazRepository, TasinmazService>();
            services.AddSingleton<ILogRepository, LogService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tasinmaz", Version = "v1" });
            });
            services.AddSwaggerDocument();
            // services.AddCors();
            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.UseMemberCasing().SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //*
                // app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasinmaz v1"));
            }
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            // app.UseCors(x=>
            //         x.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowCredentials()
            //     );
            app.UseEndpoints(endpoints => //*
            {
                endpoints.MapControllers();
            });
        }
    }

    internal interface IMahalleRepository
    {
        Task Add(Mahalle entity);
    }
}
