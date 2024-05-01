using System;
using StarWars.API.Models;

namespace StarWars.API.Services
{
	public interface IStarWarsService
	{
		Task<dynamic?> GetMoviesAsync(CancellationToken cancellationToken);
		Task<MovieModel?> GetMovieByIdAsync(int moveId, CancellationToken cancellationToken);
		Task<List<CharacterModel>?> GetCharactersAsync(CancellationToken cancellationToken);
		Task<CharacterModel?> GetCharacterByIdAsync(int characterId, CancellationToken cancellationToken);
		Task<PlanetModel?> GetPlanetByIdAsync(int planetId, CancellationToken cancellationToken);
		Task<List<PlanetModel>?> GetPlanetsAsync(CancellationToken cancellationToken);
		Task<dynamic?> GetVehicleAsync(CancellationToken cancellationToken);
	}
}

