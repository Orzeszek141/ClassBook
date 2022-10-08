using ClassBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassBook.DAL.EntityConfigurations;

internal class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        //Properties
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ClassNumber).HasMaxLength(50).IsRequired();
        builder.Property(x => x.NumberOfComputers).IsRequired();
        builder.Property(b => b.Floor).IsRequired();

        //Many-to-Many (User-Class)
        //Without any new properties EF will create new table itself with relationship many to many
    }
}