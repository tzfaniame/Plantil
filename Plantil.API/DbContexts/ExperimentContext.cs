using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Plantil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plantil.API.DbContexts
{
    public class ExperimentContext : DbContext
    {
        public ExperimentContext(DbContextOptions<ExperimentContext> options)
            : base(options)
        {

        }

        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>().HasData(
                new Plant
                {
                    Id = Guid.NewGuid(),
                    Name = PlantNameType.Limequat.ToString(),
                    Genus = GenusType.Citrus.ToString(),
                    PlantingDate = new DateTime(2020, 5, 1),
                    Multiplication = MultiplicationType.Sapling
                },
                new Plant
                {
                    Id = Guid.NewGuid(),
                    Name = PlantNameType.Kumquat.ToString(),
                    Genus = GenusType.Citrus.ToString(),
                    PlantingDate = new DateTime(2020, 5, 2),
                    Multiplication = MultiplicationType.Sapling
                },
                new Plant
                {
                    Id = Guid.NewGuid(),
                    Name = PlantNameType.Rose.ToString(),
                    Genus = GenusType.Rosa.ToString(),
                    PlantingDate = new DateTime(2020, 5, 1),
                    Multiplication = MultiplicationType.Twig
                });
        }
    }
}