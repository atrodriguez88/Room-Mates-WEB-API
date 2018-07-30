using System;
using System.IO;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NLog;
using RoomM.API.Core;
using RoomM.API.Core.Log;
using RoomM.API.Core.Models.Auth;
using RoomM.API.Core.Repository;
using RoomM.API.Persistent;
using RoomM.API.Persistent.Repository;
using RoomM.API.Service;

namespace RoomM.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddTransient<IPhotoStorage, FileSystemPhotoStore>();
            services.AddTransient<IPhotoService, PhotoService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<IRoomFeature, RoomFeatureRepository>();
            services.AddScoped<IRoomFeatureService, RoomFeatureService>();

            services.AddScoped<IPropertyType, PropertyTypeRepository>();
            services.AddScoped<IPropertyTypeService, PropertyTypeService>();

            services.AddScoped<IPropertyFeature, PropertyFeaturesRepository>();
            services.AddScoped<IPropertyFeaturesService, PropertyFeaturesService>();

            services.AddScoped<IOcupationService, OcupationService>();
            services.AddScoped<IOcupationRepository, OcupationRepository>();

            services.AddScoped<IRuleRepository, RuleRepository>();
            services.AddScoped<IRuleService, RuleService>();
            
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileService, ProfileService>();

            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomService, RoomService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add the logger service
            services.AddSingleton<ILoggerManager, LoggerService>();

            services.AddAutoMapper();
            services.AddDbContext<RoomMDbContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<RoomMDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters{
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = "yourdomain.com",
                     ValidAudience = "yourdomain.com",
                     IssuerSigningKey = new SymmetricSecurityKey(
                                        // Encoding.UTF8.GetBytes(Configuration["Llave_super_secreta"])),
                                        Encoding.UTF8.GetBytes("Llave_super_secreta")),
                     ClockSkew = TimeSpan.Zero
                 });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseCors(web => web.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseMvc();
        }
    }
}
