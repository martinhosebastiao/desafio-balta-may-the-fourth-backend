using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations;

public class StarshipConfiguration : IEntityTypeConfiguration<StarshipModel>
{
    public void Configure(EntityTypeBuilder<StarshipModel> builder)
    {
        builder.ToTable("starships");
        builder.HasKey(x => x.StarshipId);

        builder.Property(x => x.StarshipId).HasColumnName("Id");
        builder.Property(x => x.StarshipId).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100); 
        builder.Property(x => x.Name).HasColumnName("name");

        builder.Property(x => x.Model).HasColumnName("model");

        builder.Property(x => x.Manufacturer).HasColumnName("manufacturer");

        builder.Property(x => x.CostInCredits).HasColumnName("cost_in_credits");

        builder.Property(x => x.Length).HasColumnName("length");

        builder.Property(x => x.MaxAtmospheringSpeed).HasColumnName("max_atmosphering_speed");

        builder.Property(x => x.Crew).HasColumnName("crew");

        builder.Property(x => x.Passengers).HasColumnName("passengers");
        
        builder.Property(x => x.Passengers).HasDefaultValue(string.Empty);

        builder.Property(x => x.CargoCapacity).HasColumnName("cargo_capacity");

        builder.Property(x => x.HyperdriveRating).HasColumnName("hyperdrive_rating");

        builder.Property(x => x.MGLT).HasColumnName("mglt");

        builder.Property(x => x.Consumables).HasColumnName("consumables");

        builder.Property(x => x.StarshipClass).HasColumnName("starship_class");
    }
}
