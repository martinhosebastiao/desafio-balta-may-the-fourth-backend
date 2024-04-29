using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations;

public class StarshipConfiguration : IEntityTypeConfiguration<StarshipModel>
{
    public void Configure(EntityTypeBuilder<StarshipModel> builder)
    {
        builder.ToTable("spaceships");

        builder.HasKey(x => x.StarshipId);
        builder.Property(x => x.StarshipId)
            .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasColumnName("name");

        builder.Property(x => x.Model)
            .HasColumnName("model");

        builder.Property(x => x.Manufacturer)
            .HasColumnName("manufacturer");

        builder.Property(x => x.CostInCredits)
            .HasColumnName("costInCredits");

        builder.Property(x => x.Length)
            .HasColumnName("length");

        builder.Property(x => x.MaxAtmospheringSpeed)
            .HasColumnName("maxSpeed");

        builder.Property(x => x.Crew)
            .HasColumnName("crew");

        builder.Property(x => x.MaxAtmospheringSpeed)
            .HasColumnName("maxSpeed");

        builder.Property(x => x.Passengers)
            .HasColumnName("passengers");

        builder.Property(x => x.CargoCapacity)
            .HasColumnName("cargoCapacity");

        builder.Property(x => x.HyperdriveRating)
            .HasColumnName("hyperdriveRating");

        builder.Property(x => x.MaxAtmospheringSpeed)
            .HasColumnName("maxSpeed");

        builder.Property(x => x.MGLT)
            .HasColumnName("mglt");

        builder.Property(x => x.Consumables)
            .HasColumnName("consumables");

        builder.Property(x => x.StarshipClass)
            .HasColumnName("class");
    }
}
