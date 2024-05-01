using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations;

public class StarshipRelationshipConfiguration : IEntityTypeConfiguration<StarshipRelationshipModel>
{
    public void Configure(EntityTypeBuilder<StarshipRelationshipModel> builder)
    {
        builder.ToTable("StarshipRelationship");
        builder.HasKey(x => x.StarshipRelationshipId);

        builder.Property(x => x.StarshipRelationshipId)
            .HasColumnName("StarshipRelationshipId")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StarshipId)
            .HasColumnName("StarshipId");

        builder.Property(x => x.TargetId)
           .HasColumnName("TargetId");

        builder.Property(p => p.Type).HasConversion(k => ((byte)k), j =>
            (StarshipTargetType)Enum.Parse(typeof(StarshipTargetType), j.ToString()))
                           .HasColumnName("StarshipTargetType")
                           .HasColumnType("tinyint");
    }
}
