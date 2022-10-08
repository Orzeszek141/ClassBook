using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClassBook.Domain.Entities;

namespace ClassBook.DAL.EntityConfigurations;

internal class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        //Properties
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PhoneNumber).HasMaxLength(9).IsRequired();
        builder.Property(x => x.BirthDate).IsRequired();
    }
}