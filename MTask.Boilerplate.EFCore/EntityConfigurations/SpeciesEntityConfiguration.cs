using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTask.Boilerplate.Core;
using MTask.Boilerplate.Core.People;
using MTask.Boilerplate.Core.Species;

namespace MTask.Boilerplate.EFCore.EntityConfigurations;

public class SpeciesEntityConfiguration : IEntityTypeConfiguration<Specie>
{
    public void Configure(EntityTypeBuilder<Specie> builder)
    {
        builder.ToTable("Species");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Created).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAdd()
            .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(s => s.LastUpdateDate).HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAddOrUpdate()
            .Metadata
            .SetAfterSaveBehavior(PropertySaveBehavior.Save);
        
        // TODO change this to normal relationship 
        builder
            .HasMany(person => person.People)
            .WithMany(specie => specie.Species)
            .UsingEntity<PeopleSpecies>(
                j => j
                    .HasOne(pt => pt.Person)
                    .WithMany()
                    .HasForeignKey(pt => pt.PersonId).IsRequired(false)
                    .OnDelete(DeleteBehavior.ClientCascade),
                j => j
                    .HasOne(pt => pt.Specie)
                    .WithMany()
                    .HasForeignKey(pt => pt.SpecieId)
                    .OnDelete(DeleteBehavior.ClientCascade),
                j => { j.HasKey(t => new {t.PersonId, t.SpecieId}); });
    }
}