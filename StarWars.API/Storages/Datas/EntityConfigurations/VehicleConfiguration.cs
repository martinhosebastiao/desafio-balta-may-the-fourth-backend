using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations;

public class VehicleConfiguration : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.ToTable("vehicles");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();


        builder.Property(v => v.Name)
            .HasColumnName("name");

        builder.Property(v => v.Model)
            .HasColumnName("model");

        builder.Property(v => v.Manufacturer)
            .HasColumnName("manufacturer");

        builder.Property(v => v.Length)
            .HasColumnName("length");

        builder.Property(v => v.Crew)
            .HasColumnName("crew");

        builder.Property(v => v.Passengers)
            .HasColumnName("passengers");

        builder.Property(v => v.Consumables)
           .HasColumnName("consumables");

        builder.Property(v => v.CostInCredits)
           .HasColumnName("cost_in_credits");

        builder.Property(v => v.CargoCapacity)
           .HasColumnName("cargo_capacity");

        builder.Property(v => v.MaxSpeed)
            .HasColumnName("max_atmosphering_speed");

        builder.Property(v => v.Class)
            .HasColumnName("vehicle_class");


        builder.Ignore(x => x.Movies);
    }
}