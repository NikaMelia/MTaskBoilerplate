using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTask.Boilerplate.Core.Vehicles;

namespace MTask.Boilerplate.EFCore.EntityConfigurations;

public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Created).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAdd()
            .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(v => v.LastEdited).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAddOrUpdate().Metadata
            .SetAfterSaveBehavior(PropertySaveBehavior.Save);
    }
}