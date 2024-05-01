using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Common.Enums;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations
{
	public class MovieRelationshipConfiguration :
        IEntityTypeConfiguration<MovieRelationshipModel>
    {
        public void Configure(EntityTypeBuilder<MovieRelationshipModel> builder)
        {
            builder.ToTable("MovieRelationship");
            builder.HasKey(x => x.MovieRelationshipId);

            builder.Property(x => x.MovieRelationshipId)
                .HasColumnName("MovieRelationshipId")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.MovieId)
                .HasColumnName("MovieId");

            builder.Property(x => x.TargetId)
               .HasColumnName("TargetId");

            builder.Property(p => p.Type).HasConversion(k => ((byte)k), j =>
                (TargetType)Enum.Parse(typeof(TargetType), j.ToString()))
                               .HasColumnName("TargetType")
                               .HasColumnType("tinyint");
        }
    }
}

