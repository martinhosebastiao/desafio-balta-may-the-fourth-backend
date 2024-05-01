using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.Property(x => x.VehicleId)
                .HasColumnName("VehicleId");

            builder.Property(x => x.TargetId)
                .HasColumnName("TargetId");

            builder.Property(p => p.Type).HasConversion(k => ((byte)k), j =>
                (VehicleTargetType)Enum.Parse(typeof(VehicleTargetType), j.ToString()))
                               .HasColumnName("VehicleTargetType")
                               .HasColumnType("tinyint");
        }
    }
}