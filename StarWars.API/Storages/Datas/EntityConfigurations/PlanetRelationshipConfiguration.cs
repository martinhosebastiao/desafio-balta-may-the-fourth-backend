using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations;

public class PlanetRelationshipConfiguration : IEntityTypeConfiguration<PlanetRelationshipModel>
{
    public void Configure(EntityTypeBuilder<PlanetRelationshipModel> builder)
    {
        builder.ToTable("PlanetRelationship");
        builder.HasKey(x => x.PlanetRelationshipId);

        builder.Property(x => x.PlanetRelationshipId)
            .HasColumnName("PlanetRelationshipId")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.PlanetId)
            .HasColumnName("PlanetId");

        builder.Property(x => x.TargetId)
           .HasColumnName("TargetId");

        builder.Property(p => p.Type).HasConversion(k => ((byte)k), j =>
            (PlanetTargetType)Enum.Parse(typeof(PlanetTargetType), j.ToString()))
                           .HasColumnName("PlanetTargetType")
                           .HasColumnType("tinyint");
    }
}
