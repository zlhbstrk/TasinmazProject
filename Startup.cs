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
            //services.AddDbContext<DefaultDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            // services.AddControllers().AddJsonOptions(options =>
            //          {
            //              // Use the default property (Pascal) casing.
            //              options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //          }
            //     );  //*
            services.AddSingleton<IRepository<Kullanici>, KullaniciService>();
            services.AddSingleton<IRepository<Il>, IlService>();
            services.AddSingleton<IRepository<Ilce>, IlceService>();
            services.AddSingleton<IRepository<Mahalle>, MahalleService>();
            services.AddSingleton<IRepository<ETasinmaz>, TasinmazService>();
            services.AddSingleton<IRepository<Log>, LogService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tasinmaz", Version = "v1" });
            });
            services.AddSwaggerDocument();
            services.AddCors();
            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.UseMemberCasing().SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseEndpoints(endpoints => //*
            {
                endpoints.MapControllers();
            });
        }
    }
}
