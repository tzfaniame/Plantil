using Microsoft.EntityFrameworkCore;
using Plantil.Domain.Entities;
using System;

namespace Plantil.Data
{
    public class PlantContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Taxonomy> Taxonomys { get; set; }
        public DbSet<GrowthRecommend> GrowthRecommends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=MESHULAM\SQLEXPRESS19;Database=PlantilDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<PlantExperiment>().HasKey(p =>new { p.PlantId , p.ExperimentId});
            //force EF to named  table that represent entity of Planter that has not dbset
            modelBuilder.Entity<Planter>().ToTable("Planters");
        }
    }
}
