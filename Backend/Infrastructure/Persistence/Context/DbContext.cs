
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
}