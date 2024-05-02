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

        Task<List<CharacterModel>?> GetCharactersAsync(
            CancellationToken cancellationToken = default);

        Task<CharacterModel?> GetCharacterByIdAsync(
            int characterId,
            CancellationToken cancellationToken = default);

        Task<CharacterModel?> GetCharacterByNameAsync(string name,
            CancellationToken cancellationToken = default);

        Task<CharacterModel?> CreateCharacterAsync(
            CharacterModel model, CancellationToken cancellationToken = default);

        Task<PlanetModel?> GetPlanetByIdAsync(
           int planetId,
           CancellationToken cancellationToken = default);

        Task<PlanetModel?> GetPlanetByNameAsync(
            string name,
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

        Task<StarshipModel?> GetStarshipByNameAsync(string name,
            CancellationToken cancellationToken = default);

        Task<StarshipModel?> CreateStarshipAsync(
            StarshipModel model,
            CancellationToken cancellationToken = default);

        Task<List<StarshipModel>?> GetStarshipsAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Cria um novo Veiculo
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Retorna os dados do veiculo criado, em caso de sucesso</returns>
        Task<VehicleModel?> CreateVehicleAsync(VehicleModel model,
            CancellationToken cancellationToken = default);

        Task<VehicleModel?> GetVehicleByIdAsync(
            int Id,
            CancellationToken cancellationToken = default);

        Task<MovieRelationshipModel?> CreateRelationalShipAsync(
            MovieRelationshipModel model,
            CancellationToken cancellationToken = default);

        Task<PlanetRelationshipModel?> CreatePlanetRelationshipAsync(
            PlanetRelationshipModel model,
            CancellationToken cancellationToken = default);

        Task<StarshipRelationshipModel?> CreateStarshipRelationshipAsync(
            StarshipRelationshipModel model,
            CancellationToken cancellationToken = default);
      
        Task<VehicleRelationshipModel?> CreateVehicleRelationalShipAsync(
        VehicleRelationshipModel model,
        CancellationToken cancellationToken = default);

        Task<CharacterRelationshipModel?> CreateCharacterRelationshipAsync(
            CharacterRelationshipModel model,
            CancellationToken cancellationToken = default);
    }
}

