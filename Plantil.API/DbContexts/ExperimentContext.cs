using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Plantil.Core;
using Plantil.API.Entities;
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
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = PlantNameType.Limequat.ToString(),
                    Genus = GenusType.Citrus.ToString(),
                    PlantingDate = new DateTime(2020, 5, 1),
                    Multiplication = MultiplicationType.Sapling
                },
                new Plant
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = PlantNameType.Kumquat.ToString(),
                    Genus = GenusType.Citrus.ToString(),
                    PlantingDate = new DateTime(2020, 5, 2),
                    Multiplication = MultiplicationType.Sapling
                },
                new Plant
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = PlantNameType.Rose.ToString(),
                    Genus = GenusType.Rosa.ToString(),
                    PlantingDate = new DateTime(2020, 5, 1),
                    Multiplication = MultiplicationType.Twig
                });

            modelBuilder.Entity<Experiment>().HasData(
                new Experiment
                {
                    Id = Guid.NewGuid(),
                    PlantId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    ExperimentDate = new DateTime(2020, 5, 20),
                    Description = "שתילת עציץ במרפסת"
                },
                new Experiment
                {
                    Id = Guid.NewGuid(),
                    PlantId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    ExperimentDate = new DateTime(2020, 5, 23),
                    Description = "קטימת עלים תחתונים"
                },
                new Experiment
                {
                    Id = Guid.NewGuid(),
                    PlantId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    ExperimentDate = new DateTime(2020, 5, 20),
                    Description = "העברת עץ מאדמה לדלי"
                },
                new Experiment
                {
                    Id = Guid.NewGuid(),
                    PlantId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    ExperimentDate = new DateTime(2020, 5, 23),
                    Description = "השקייה מלאה"
                },
                new Experiment
                {
                    Id = Guid.NewGuid(),
                    PlantId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    ExperimentDate = new DateTime(2020, 5, 23),
                    Description = "קטימת קצות ענפים"
                },
                new Experiment
                {
                    Id = Guid.NewGuid(),
                    PlantId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    ExperimentDate = new DateTime(2020, 5, 20),
                    Description = "הדליה אופקית"
                }
                );
        }
    }
}