using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OA_Repository.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Repository
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
     
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeHistory> ExchangeHistories { get; set; }
    }
}
