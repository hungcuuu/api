using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.BussinessLogics;
using BLL.Helpers;
using BLL.Interfaces;
using DAL.Models;
using DAL.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API
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
            #region Get Config
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingsSection);

            // configure startup page
            var helpPage = Configuration.GetSection("HelpContent");
            services.Configure<HelpPage>(helpPage);

            // configure startup page
            var indexPage = Configuration.GetSection("IndexContent");
            services.Configure<IndexPage>(indexPage);

            // configure admin guidance
            var adminGuide = Configuration.GetSection("AdminGuide");
            services.Configure<AdminGuide>(adminGuide);

            // configure admin guidance
            var login = Configuration.GetSection("LoginGuide");
            services.Configure<LoginGuide>(login);

            // configure admin guidance
            var register = Configuration.GetSection("RegisterGuide");
            services.Configure<RegisterGuide>(register);
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
            #endregion
            #region JWT
            var projectId = "fir-demo-cf7fa";
           // var projectId = "projectswd-4b664";
            services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Audience = projectId;
            options.Authority = "https://securetoken.google.com/"+ projectId;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "https://securetoken.google.com/"+ projectId,
                ValidateAudience = true,
                ValidAudience = projectId,
                ValidateLifetime = true
            };
        });
            #endregion

            #region cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddControllers();
            #endregion
            #region Dependency
            services.AddScoped<IUnitOfWork, UnitOfWork>();
          //   services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IGuestLogic, GuestLogic>();
         //    services.AddScoped<IAdminLogic, AdminLogic>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region DBConnection
            services.AddDbContext<PointOfSaleDBPassioContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DB")));
            #endregion
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
             
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
       //     app.UseAuthorization();
            app.UseCors();
            app.UseMvc();
       //     app.UseEndpoints(endpoints =>
       //     {
       //         endpoints.MapControllerRoute(
       // name: "default",
       //// pattern: "{controller=Home}/{action=Index}/{id?}");
       // pattern: "v1/{controller=Home}/{id?}");
       //     });

        }

    }
}
