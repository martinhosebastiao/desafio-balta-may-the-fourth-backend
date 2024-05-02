using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Common.Enums;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations
{
  public class VehicleRelationshipConfiguration : IEntityTypeConfiguration<VehicleRelationshipModel>
  {
    public void Configure(EntityTypeBuilder<VehicleRelationshipModel> builder)
    {
      builder.ToTable("VehicleRelationship");
      builder.HasKey(x => x.VehicleRelationshipId);

      builder.Property(x => x.VehicleRelationshipId)
          .HasColumnName("VehicleRelationshipId")
          .ValueGeneratedOnAdd();

      builder.Property(x => x.VehicleId).HasColumnName("VehicleId");

      builder.Property(x => x.TargetId).HasColumnName("TargetId");

      builder.Property(p => p.Type).HasConversion(k => ((byte)k), j =>
          (TargetType)Enum.Parse(typeof(TargetType), j.ToString()))
                    .HasColumnName("TargetType")
                    .HasColumnType("tinyint");
    }
  }
}