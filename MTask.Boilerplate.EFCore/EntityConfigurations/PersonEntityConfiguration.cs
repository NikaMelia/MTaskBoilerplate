using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTask.Boilerplate.Core.People;

namespace MTask.Boilerplate.EFCore.EntityConfigurations;

public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Created).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAdd()
            .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(p => p.LastEdited).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAddOrUpdate().Metadata
            .SetAfterSaveBehavior(PropertySaveBehavior.Save);
    }
}