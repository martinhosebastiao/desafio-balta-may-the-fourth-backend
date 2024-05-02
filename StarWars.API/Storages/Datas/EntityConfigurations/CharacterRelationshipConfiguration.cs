using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations;

public class CharacterRelationshipConfiguration : IEntityTypeConfiguration<CharacterRelationshipModel>
{
    public void Configure(EntityTypeBuilder<CharacterRelationshipModel> builder)
    {
        builder.ToTable("CharacterRelationship");
        builder.HasKey(x => x.CharacterRelationshipId);

        builder.Property(x => x.CharacterRelationshipId)
            .HasColumnName("CharacterRelationshipId")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CharacterId)
            .HasColumnName("CharacterId");

        builder.Property(x => x.TargetId)
           .HasColumnName("TargetId");

        builder.Property(p => p.Type).HasConversion(k => ((byte)k), j =>
            (CharacterTargetType)Enum.Parse(typeof(CharacterTargetType), j.ToString()))
                           .HasColumnName("CharacterTargetType")
                           .HasColumnType("tinyint");
    }
}
