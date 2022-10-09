using ClassBook.DAL.EntityConfigurations;
using ClassBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.DAL;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Class> Classes { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClassConfiguration());
        modelBuilder.ApplyConfiguration(new FacultyConfiguration());
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}