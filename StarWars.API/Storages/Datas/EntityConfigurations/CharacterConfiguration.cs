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
        
        builder.Property(x => x.Id)
            .HasColumnName("Id");

        builder.Property(x => x.Name)
            .HasColumnName("name");

        builder.Property(x => x.Height)
            .HasColumnName("height");

        builder.Property(x => x.Mass)
            .HasColumnName("mass");

        builder.Property(x => x.HairColor)
               .HasColumnName("hair_color"); 

        builder.Property(x => x.SkinColor) 
               .HasColumnName("skin_color");

        builder.Property(x => x.EyeColor)
               .HasColumnName("eye_color");

        builder.Property(x => x.BirthYear)
               .HasColumnName("birth_year");

        builder.Property(x => x.Gender)
            .HasColumnName("gender");

        builder.Ignore(x => x.Planet);
        builder.Ignore(x => x.Movies);
    }
}
