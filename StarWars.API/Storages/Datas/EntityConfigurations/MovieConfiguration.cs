using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.API.Models;

namespace StarWars.API.Storages.Datas.EntityConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<MovieModel>
    {

        public void Configure(EntityTypeBuilder<MovieModel> builder)
        {
            builder.ToTable("movies");

            builder.HasKey(x=> x.Id);
            builder.Property(x=> x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasColumnName("title");

            builder.Property(x => x.EpisodeId)
                .HasColumnName("episode");

            builder.Property(x => x.OpeningCrawl)
                .HasColumnName("openingCrawl");

            builder.Property(x => x.Director)
                .HasColumnName("director");

            builder.Property(x => x.Producer)
                .HasColumnName("producer");

            builder.Property(x => x.ReleaseDate)
                .HasColumnName("releaseDate");

            builder.Property(x => x.Url)
               .HasColumnName("Url");

            builder.Ignore(x => x.Characters);
            builder.Ignore(x=> x.Planets);
            builder.Ignore(x=> x.Vehicles);
            builder.Ignore(x=> x.Starships);
        }
    }
}

