using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Device_Management_System.Authentication;
using Device_Management_System.DatabaseContext;
using Device_Management_System.Repository;
using Device_Management_System.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Device_Management_System
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
            services.AddDbContext<DmsDbContext>(opt => opt.UseSqlServer
                (Environment.GetEnvironmentVariable("CONNECTIONSTRING")));

            //Authentication DbContext
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTIONSTRING")));

            // For Identity 
            services.AddIdentity<ApplicationUser, IdentityRole>() 
            .AddEntityFrameworkStores<ApplicationDbContext>() 
            .AddDefaultTokenProviders();

             // Adding Authentication 
            services.AddAuthentication(options => 
            { 
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; 
            })

            // Adding Jwt Bearer 
            .AddJwtBearer(options => 
            { 
                options.SaveToken = true; 
                options.RequireHttpsMetadata = false; 
                options.TokenValidationParameters = new TokenValidationParameters() 
                { 
                    ValidateIssuer = true, 
                    ValidateAudience = true, 
                    ValidAudience = Configuration["JWT:ValidAudience"], 
                    ValidIssuer = Configuration["JWT:ValidIssuer"], 
                    IssuerSigningKey = new 
                    SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SECRETE"])) 
                }; 
            }); 

            

            services.AddScoped<IZone, ZoneImp>();
            services.AddScoped<ICategory, CategoryImp>();
            services.AddScoped<IDevice, DeviceImp>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Device_Management_System", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Device_Management_System v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
