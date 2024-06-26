using System;
using StarWars.API.Models;

namespace StarWars.API.Services
{
	public interface IStarWarsService
	{
		Task<dynamic?> GetMoviesAsync(CancellationToken cancellationToken);
		Task<MovieModel?> GetMovieByIdAsync(int moveId, CancellationToken cancellationToken);
		Task<dynamic> GetCharactersAsync(CancellationToken cancellationToken);
		Task<CharacterModel?> GetCharacterByIdAsync(int characterId, CancellationToken cancellationToken);
		Task<PlanetModel?> GetPlanetByIdAsync(int planetId, CancellationToken cancellationToken);
		Task<dynamic?> GetPlanetsAsync(CancellationToken cancellationToken);
		Task<dynamic?> GetVehicleAsync(CancellationToken cancellationToken);
		Task<dynamic?> GetStarshipsAsync(CancellationToken cancellationToken = default);

    }
}

