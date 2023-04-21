using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTask.Boilerplate.Core.Films;

namespace MTask.Boilerplate.EFCore.EntityConfigurations;

public class FilmEntityConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.ToTable("Films");
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Created).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAdd()
            .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(f => f.LastEdited).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAddOrUpdate().Metadata
            .SetAfterSaveBehavior(PropertySaveBehavior.Save);
    }
}