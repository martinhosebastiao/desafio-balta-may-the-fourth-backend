using System.Configuration;
using Microsoft.EntityFrameworkCore;
using StarWars.API.Models;
using StarWars.API.Storages.Datas.EntityConfigurations;

namespace StarWars.API.Storages.Datas
{
    public class StarWarsContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public StarWarsContext(DbContextOptions<StarWarsContext> options,
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region - Configuração de DbSets -
        public DbSet<MovieModel> Movies { get; private set; }
        public DbSet<CharacterModel> Characters { get; private set; }
        public DbSet<PlanetModel> Planets { get; private set; }
        public DbSet<StarshipModel> Spaceships { get; private set; }
        public DbSet<VehicleModel> Vehicles { get; private set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var mySqlConnection = _configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySql(
                   mySqlConnection,
                   ServerVersion.AutoDetect(mySqlConnection));

            optionsBuilder.EnableServiceProviderCaching();
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterConfiguration());
            modelBuilder.ApplyConfiguration(new PlanetConfiguration());
            modelBuilder.ApplyConfiguration(new StarshipConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());


            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Property);

            base.OnModelCreating(modelBuilder);
        }
    }
}

