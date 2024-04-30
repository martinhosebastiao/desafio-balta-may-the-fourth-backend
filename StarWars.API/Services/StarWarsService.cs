using StarWars.API.Models;
using StarWars.API.Storages.Repositores;

namespace StarWars.API.Services
{
    public class StarWarsService: IStarWarsService
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

        public async Task<List<MovieModel>?> GetMoviesAsync(CancellationToken cancellationToken)
        {
            var movies = await _starWarsRepository.GetMoviesAsync(cancellationToken);

            return movies;
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
            var characters = await _starWarsRepository.GetPlanetsAsync(cancellationToken);

            return characters;
        }
        
        public async Task<List<VehicleModel>?> GetVehicleAsync(CancellationToken cancellationToken)
        {
            var vehicle = await _starWarsRepository.GetVehicleAsync(cancellationToken);
            return vehicle;
        }
    }
}

