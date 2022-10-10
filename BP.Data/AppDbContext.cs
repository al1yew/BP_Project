using BP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Weight> Weights { get; set; }
        public DbSet<Distance> Distances { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<WeightToDistanceToFrequency> WeightToDistanceToFrequencies { get; set; }

    }
}
