using StarWars.API.Models;

namespace StarWars.API.Storages.Repositores
{
    public interface IStarWarsRepository
    {
        Task<List<MovieModel>?> GetMoviesAsync(
            CancellationToken cancellationToken = default);

        Task<MovieModel?> GetMovieByIdAsync(
            int movieId,
            CancellationToken cancellationToken = default);

        Task<MovieModel?> GetMovieByTitleAsync(
           string title,
           CancellationToken cancellationToken = default);

        Task<MovieModel?> CreateMovieAsync(
            MovieModel model, CancellationToken cancellationToken = default);

		Task<CharacterModel?> GetCharacterByIdAsync(
			int characterId, 
			CancellationToken cancellationToken = default);

		Task<CharacterModel?> CreateCharacterAsync(
			CharacterModel model,  CancellationToken cancellationToken = default);

		Task<PlanetModel?> GetPlanetByIdAsync(
		   int planetId,
		   CancellationToken cancellationToken = default);

		Task<PlanetModel?> CreatePlanetAsync(
			PlanetModel model,
			CancellationToken cancellationToken = default);

		Task<List<PlanetModel?>> GetPlanetsAsync(
            CancellationToken cancellationToken = default);
        Task<List<CharacterModel>?> GetCharactersAsync(
            CancellationToken cancellationToken = default);

        Task<CharacterModel?> GetCharacterByIdAsync(
                int characterId,
                CancellationToken cancellationToken = default);

        Task<CharacterModel?> CreateCharacterAsync(
            CharacterModel model, CancellationToken cancellationToken = default);

        Task<PlanetModel?> GetPlanetByIdAsync(
           int planetId,
           CancellationToken cancellationToken = default);

        Task<PlanetModel?> CreatePlanetAsync(
            PlanetModel model,
            CancellationToken cancellationToken = default);

        Task<List<PlanetModel?>> GetPlanetsAsync(
                 CancellationToken cancellationToken = default);

        Task<List<VehicleModel>?> GetVehicleAsync(
            CancellationToken cancellationToken = default);

        Task<StarshipModel?> GetStarshipByIdAsync(
           int starshipId,
           CancellationToken cancellationToken = default);

        Task<StarshipModel?> CreateStarshipAsync(
            StarshipModel model,
            CancellationToken cancellationToken = default);

        Task<VehicleModel?> CreateVehicleAsync(VehicleModel model,
            CancellationToken cancellationToken = default);

        Task<VehicleModel?> GetVehicleByIdAsync(
            int Id,
            CancellationToken cancellationToken = default);

        Task<MovieRelationshipModel?> CreateRelationalShipAsync(
            MovieRelationshipModel model,
            CancellationToken cancellationToken = default);
    }
}

