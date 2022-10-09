using ClassBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassBook.DAL.EntityConfigurations;

internal class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        //Properties
        builder.HasKey(x => x.Id);
        builder.HasIndex(b => b.PhoneNumber).IsUnique();
        builder.Property(x => x.PhoneNumber).HasMaxLength(9).IsRequired();
        builder.Property(x => x.BirthDate).IsRequired();
    }
}