
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public partial class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Skills> Skills { get; set; }
    public DbSet<SupportUrls> SupportUrls { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<PersonalInfo> PersonalInfos { get; set; }
    public DbSet<Reference> References { get; set; }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // configurationBuilder.Properties<Guid>().UseCollation("utf8mb4_unicode_ci");
        // configurationBuilder.Properties<string>().UseCollation("utf8mb4_unicode_ci");

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //optionsBuilder.UseMySQL("server=localhost;user=admin;pwd=admin;database=topic_creator");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}