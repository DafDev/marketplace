﻿using Marketplace.Domain.Contexts.Ad.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Marketplace.Infrastructure.Contexts;
public class ClassifiedAdDbContext(DbContextOptions<ClassifiedAdDbContext> options, ILoggerFactory loggerFactory) : DbContext(options)
{
    private readonly ILoggerFactory _loggerFactory = loggerFactory;

    public DbSet<ClassifiedAd> ClassifiedAds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(new ClassifiedAdEntityTypeConfiguration());

}