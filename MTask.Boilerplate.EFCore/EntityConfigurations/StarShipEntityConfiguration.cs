using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTask.Boilerplate.Core.Starships;

namespace MTask.Boilerplate.EFCore.EntityConfigurations;

public class StarShipEntityConfiguration : IEntityTypeConfiguration<StarShip>
{
    public void Configure(EntityTypeBuilder<StarShip> builder)
    {
        builder.ToTable("StarShips");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Created).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAdd()
            .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(s => s.LastEdited).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAddOrUpdate().Metadata
            .SetAfterSaveBehavior(PropertySaveBehavior.Save);
    }
}