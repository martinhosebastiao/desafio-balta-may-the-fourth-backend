﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations;

public class CharacterConfiguration : IEntityTypeConfiguration<CharacterModel>
{
    public void Configure(EntityTypeBuilder<CharacterModel> builder)
    {
        builder.ToTable("character");
        builder.HasKey(x => x.CharacterId);
        builder.Property(x => x.CharacterId).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100); 
        builder.Property(x => x.Height).HasMaxLength(20); 
        builder.Property(x => x.Weight).HasMaxLength(20); 
        builder.Property(x => x.HairColor).HasMaxLength(50); 
        builder.Property(x => x.SkinColor).HasMaxLength(50); 
        builder.Property(x => x.EyeColor).HasMaxLength(50); 
        builder.Property(x => x.BirthYear).HasMaxLength(10); 
        builder.Property(x => x.Gender).HasMaxLength(10); 
    }
}