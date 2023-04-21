using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTask.Boilerplate.Core.Planets;

namespace MTask.Boilerplate.EFCore.EntityConfigurations;

public class PlanetEntityConfiguration : IEntityTypeConfiguration<Planet>
{
    public void Configure(EntityTypeBuilder<Planet> builder)
    {
        builder.ToTable("Planets");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Created).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAdd();
        builder.Property(p => p.Edited).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAddOrUpdate()
            .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc)).Metadata
            .SetAfterSaveBehavior(PropertySaveBehavior.Save);
    }
}