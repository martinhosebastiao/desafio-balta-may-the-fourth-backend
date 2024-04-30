using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations;

public class CharacterConfiguration : IEntityTypeConfiguration<CharacterModel>
{
    public void Configure(EntityTypeBuilder<CharacterModel> builder)
    {
        builder.ToTable("characters");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("Id");

        builder.Property(x => x.PlanetId)
            .HasColumnName("planet_id");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100); 
        builder.Property(x => x.Height).HasMaxLength(20);
        
        builder.Property(x => x.Mass).HasMaxLength(20); 

        builder.Property(x => x.HairColor).HasMaxLength(50)
               .HasColumnName("hair_color"); 

        builder.Property(x => x.SkinColor).HasMaxLength(50) 
               .HasColumnName("skin_color");

        builder.Property(x => x.EyeColor).HasMaxLength(50)
               .HasColumnName("eye_color");

        builder.Property(x => x.BirthYear).HasMaxLength(10)
               .HasColumnName("birth_year");

        builder.Property(x => x.Gender);

        builder.Ignore(x => x.Planet);
        builder.Ignore(x => x.Movies);
    }
}
