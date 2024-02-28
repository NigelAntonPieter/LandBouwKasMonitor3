using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using LandBouwKas.Model;

namespace LandBouwKas.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Gewassen> Gewassens { get; set; }
        public DbSet<Voedingstoffen> voedingstoffens { get; set; }
        public DbSet<Geschiedenis> geschiedenissen {  get; set; }
        public DbSet<GewassenVoedingstoffen> gewassenVoedingstoffens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseMySql(
               ConfigurationManager.ConnectionStrings["LandbouwKasMonitor"].ConnectionString,
               ServerVersion.Parse("5.7.33-winx64"));
        }
    }
}
