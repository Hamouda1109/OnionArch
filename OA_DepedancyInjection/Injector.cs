using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OA_Core.Repositories;
using OA_Core.Services;
using OA_Repository;
using OA_Repository.Auth;
using OA_Service;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;


namespace OA_DepedancyInjection
{
    public class Injector
    {
        public IConfiguration Configuration { get; }

        public Injector(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Injection(IServiceCollection services)
        {
             services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
             services.AddTransient<ICurrencyService<Currency>,CurrencyService>();
             services.AddTransient<ICurrency<Currency>, CurrencyRepository>();
             services.AddTransient<IHistoryRepository<ExchangeHistory>, HistoryRepository>();
             services.AddTransient<IHistoryService, HistoryService>();


            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });

             // Adding Jwt Bearer  
             /*.AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });*/

        }
    }
}
