using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClassBook.Domain.Entities;

namespace ClassBook.DAL.EntityConfigurations;

internal class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        //Properties
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FacultyName).HasMaxLength(200).IsRequired();
        builder.Property(x => x.City).HasMaxLength(200).IsRequired();
        builder.Property(x => x.PostalCode).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Street).HasMaxLength(200).IsRequired();
        builder.Property(x => x.BuildingNb).HasMaxLength(200).IsRequired();

        //One-to-Many (Faculty-Class)
        builder.HasMany(c => c.Classes).WithOne(f => f.Faculty).HasForeignKey(x => x.FacultyId);
    }
}