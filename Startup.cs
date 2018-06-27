﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RoomM.API.Core;
using RoomM.API.Core.Entity;
using RoomM.API.Core.Models;
using RoomM.API.Persistent;
using RoomM.API.Persistent.Entity;
using RoomM.API.Service;

namespace RoomM.API
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRoomFeature, RoomFeatureRepository>();
            services.AddScoped<IPropertyType, PropertyTypeRepository>();
            services.AddScoped<IPropertyFeature, PropertyFeaturesRepository>();

            services.AddScoped<IOcupationService, OcupationService>();
            services.AddScoped<IOcupationRepository, OcupationRepository>();

            services.AddScoped<IRuleRepository, RuleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
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
                    
            services.AddMvc();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors(web => web.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseMvc();
        }
    }
}
