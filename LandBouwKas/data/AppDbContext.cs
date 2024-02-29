using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using LandBouwKas.Model;
using LandBouwKas.ApiModels;

namespace LandBouwKas.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<CashData> CashData { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseMySql(
               ConfigurationManager.ConnectionStrings["LandbouwKasMonitor"].ConnectionString,
               ServerVersion.Parse("5.7.33-winx64"));
        }
    }
}
