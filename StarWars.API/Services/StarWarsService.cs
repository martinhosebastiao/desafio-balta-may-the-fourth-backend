using StarWars.API.Models;
using StarWars.API.Storages.Repositores;

namespace StarWars.API.Services
{
    public class StarWarsService : IStarWarsService
    {
        private readonly IStarWarsRepository _starWarsRepository;

        public StarWarsService(IStarWarsRepository starWarsRepository)
        {
            _starWarsRepository = starWarsRepository;
        }

        public async Task<MovieModel?> GetMovieByIdAsync(int moveId, CancellationToken cancellationToken)
        {
            var movie = await _starWarsRepository.GetMovieByIdAsync(moveId, cancellationToken);

            return movie;
        }

        public async Task<dynamic?> GetMoviesAsync(CancellationToken cancellationToken)
        {
            var movies = await _starWarsRepository.GetMoviesAsync(cancellationToken);

            if (movies is null)
            {
                return null;
            }

            var _movies = movies.Select(x => new
            {
                x.Title,
                episode = x.EpisodeId,
                x.OpeningCrawl,
                x.Director,
                x.Producer,
                x.ReleaseDate,
                characters = x.Characters?.Select(k => new
                {
                    k.Id,
                    k.Name
                }).ToList(),
                planets = x.Planets?.Select(k => new
                {
                    k.Id,
                    k.Name
                }).ToList(),
                vehicles = x.Vehicles?.Select(k => new
                {
                    k.Id,
                    k.Name
                }).ToList(),
                starships = x.Starships?.Select(k => new
                {
                    k.Id,
                    k.Name
                }).ToList(),

            }).ToList();

            return _movies;
        }

        public async Task<CharacterModel?> GetCharacterByIdAsync(int characterId, CancellationToken cancellationToken)
        {
            var character = await _starWarsRepository.GetCharacterByIdAsync(characterId, cancellationToken);


            return character;
        }

        public async Task<List<CharacterModel>?> GetCharactersAsync(CancellationToken cancellationToken)
        {
            var characters = await _starWarsRepository.GetCharactersAsync(cancellationToken);

            return characters;
        }

        public async Task<PlanetModel?> GetPlanetByIdAsync(int planetId, CancellationToken cancellationToken)
        {
            var planet = await _starWarsRepository.GetPlanetByIdAsync(planetId, cancellationToken);

            return planet;
        }

        public async Task<dynamic> GetPlanetsAsync(CancellationToken cancellationToken)
        {
            var planets = await _starWarsRepository.GetPlanetsAsync(cancellationToken);

            if(planets == null)
            {
                return null;
            }

            var _planets = planets.Select(x => new
            {
                x.Name,
                x.RotationPeriod,
                x.OrbitalPeriod,
                x.Diameter,
                x.Climate,
                x.Gravity,
                x.Terrain,
                x.SurfaceWater,
                x.Population,
                residents = x.Characters?.Select(k => new
                {
                    k.Id,
                    k.Name
                }).ToList(),
                movies = x.Movies?.Select(k => new
                {
                    k.Id,
                    k.Title
                }).ToList(),

            }).ToList();

            return _planets;
        }

        public async Task<List<VehicleModel>?> GetVehicleAsync(CancellationToken cancellationToken)
        {
            var vehicle = await _starWarsRepository.GetVehicleAsync(cancellationToken);
            return vehicle;
        }
    }
}

