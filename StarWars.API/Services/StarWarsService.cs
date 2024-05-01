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

        public async Task<List<PlanetModel>?> GetPlanetsAsync(CancellationToken cancellationToken)
        {
            var planets = await _starWarsRepository.GetPlanetsAsync(cancellationToken);

            return planets;
        }

        public async Task<dynamic?> GetVehicleAsync(CancellationToken cancellationToken)
        {
            var vehicle = await _starWarsRepository.GetVehicleAsync(cancellationToken);
            var _vehicle = vehicle.Select(x => new
            {
                x.Name,
                x.Model,
                x.Manufacturer,
                x.CostInCredits,
                x.Length,
                x.MaxSpeed,
                x.Crew,
                x.Passengers,
                x.CargoCapacity,
                x.Consumables,
                x.Class,
                movies = x.Movies?.Select(k => new
                {
                    k.Id,
                    k.Title
                }).ToList()
                }).ToList();

            return vehicle;
        }
    }
}

