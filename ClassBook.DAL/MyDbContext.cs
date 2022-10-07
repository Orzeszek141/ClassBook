using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using ClassBook.Domain.Entities;

namespace ClassBook.DAL
{
    public class MyDbContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<User> Users { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
