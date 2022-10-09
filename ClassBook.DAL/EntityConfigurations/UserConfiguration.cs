using ClassBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassBook.DAL.EntityConfigurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //Properties
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
        builder.HasIndex(b => b.Email).IsUnique();
        builder.Property(x => x.Email).HasMaxLength(80).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(90).IsRequired();
        builder.Property(x => x.Role).IsRequired();

        //One-to-One (User-UserInfo)
        builder.HasOne(ui => ui.UserInfo).WithOne(u => u.User).HasForeignKey<UserInfo>(x => x.UserId);
    }
}