using StarWars.API.Models;
using StarWars.API.Models.Imports;
using StarWars.API.Storages.Repositores;

namespace StarWars.API.Services
{
    public class ImportService : IImportService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ImportService> _logger;
        private readonly IStarWarsRepository _starWarsRepository;

        public ImportService(
            ILogger<ImportService> logger,
            IStarWarsRepository starWarsRepository)
        {
            _httpClient = new HttpClient();
            _logger = logger;
            _starWarsRepository = starWarsRepository;
        }

        public async Task<bool> FromSwapiAsync(
            CancellationToken cancellationToken = default)
        {
            // Todo: Implementar os demais endpoints
            // var planets = await ImportPlanetsAsync(cancellationToken);
            var vehicles = await ImportVehiclesAsync(cancellationToken);
            var starships = await ImportStarshipsAsync(cancellationToken);
            var characters = await ImportCharactersAsync(cancellationToken);
            var movies = await ImportMoviesAsync(cancellationToken);

            return characters = movies = starships = vehicles;
        }

        private async Task<bool> ImportMoviesAsync(
            CancellationToken cancellationToken)
        {
            // Todo: Implementar os demais endpoints
            string moviesUrl = "https://swapi.py4e.com/api/films";
        
            var response = await _httpClient.GetFromJsonAsync<MovieImport>(
                moviesUrl, cancellationToken: cancellationToken);
        
            var _errors = new List<int>();
        
            if (response?.Results.Count > 0)
            {
                int i = 0;
        
                foreach (var movie in response.Results)
                {
                    var model = movie.ConvertToModel();
        
                    var existMovie = await _starWarsRepository
                        .GetMovieByIdAsync(
                        model.MovieId,
                        cancellationToken);
        
                    if (existMovie is null)
                    {
                        var _movie = await _starWarsRepository.CreateMovieAsync(
                                              model, cancellationToken);
        
                        if (_movie is null)
                        {
                            i++;
                            _errors.Add(i);
                        }
                    }
                }
            }
        
            var _response = (_errors?.Count ?? 0) == 0;
        
            return _response;
        }
        
        private async Task<bool> ImportCharactersAsync(
            CancellationToken cancellationToken)
        {
            string charactersUrl = "https://swapi.py4e.com/api/people";
        
            var response = await _httpClient.GetFromJsonAsync<CharacterImport>(
                charactersUrl, cancellationToken: cancellationToken);
        
            var _errors = new List<int>();
        
            if (response?.Results.Count > 0)
            {
                int i = 0;
        
                foreach (var character in response.Results)
                {
                    var model = character.ConvertToModel();
        
                    var existCharacter = await _starWarsRepository
                        .GetCharacterByIdAsync(
                        model.CharacterId,
                        cancellationToken);
        
                    if (existCharacter is null)
                    {
                        var _character = await _starWarsRepository.CreateCharacterAsync(
                                              model, cancellationToken);
        
                        if (_character is null)
                        {
                            i++;
                            _errors.Add(i);
                        }
                    }
                }
            }
        
            var _response = (_errors?.Count ?? 0) == 0;
        
            return _response;
        }
        
        private async Task<bool> ImportPlanetsAsync(
            CancellationToken cancellationToken)
        {
            string planetsUrl = "https://swapi.py4e.com/api/planets";
        
            var response = await _httpClient.GetFromJsonAsync<PlanetImport>(
                planetsUrl, cancellationToken: cancellationToken);
        
            var _errors = new List<int>();
        
            if (response?.Results.Count > 0)
            {
                int i = 0;
        
                foreach (var planet in response.Results)
                {
                    var model = planet.ConvertToModel();
        
                    var existPlanet = await _starWarsRepository
                        .GetPlanetByIdAsync(
                        model.PlanetId,
                        cancellationToken);
        
                    if (existPlanet is null)
                    {
                        var _planet = await _starWarsRepository.CreatePlanetAsync(
                                              model, cancellationToken);
        
                        if (_planet is null)
                        {
                            i++;
                            _errors.Add(i);
                        }
                    }
                }
            }
        
            var _response = (_errors?.Count ?? 0) == 0;
        
            return _response;
        }
        
        private async Task<bool> ImportVehiclesAsync(
            CancellationToken cancellationToken)
        {
            string vehiclesUrl = "https://swapi.py4e.com/api/vehicles";

            var response = await _httpClient.GetFromJsonAsync<VehicleInport>(
                vehiclesUrl, cancellationToken: cancellationToken);

            var _errors = new List<int>();

            if (response?.Results.Count > 0)
            {
                int i = 0;

                foreach (var vehicles in response.Results)
                {
                    var model = vehicles.ConvertToModel();

                    var existVehicles = await _starWarsRepository
                        .GetVehicleByIdAsync(
                            model.Id,
                            cancellationToken);

                    if (existVehicles is null)
                    {
                        var _vehicles= await _starWarsRepository.CreateVehicleAsync(
                            model, cancellationToken);

                        if (_vehicles is null)
                        {
                            i++;
                            _errors.Add(i);
                        }
                    }
                }
            }

            var _response = (_errors?.Count ?? 0) == 0;

            return _response;
        }

        private async Task<bool> ImportStarshipsAsync(
            CancellationToken cancellationToken)
        {
            string starshipsUrl = "https://swapi.py4e.com/api/starships";

            var response = await _httpClient.GetFromJsonAsync<StarshipImport>(
                starshipsUrl, cancellationToken: cancellationToken);

            var _errors = new List<int>();

            if (response?.Results.Count > 0)
            {
                int i = 0;

                foreach (var starship in response.Results)
                {
                    var model = starship.ConvertToModel();

                    var existStarship = await _starWarsRepository
                        .GetStarshipByIdAsync(
                        model.StarshipId,
                        cancellationToken);

                    if (existStarship is null)
                    {
                        var _starship = await _starWarsRepository.CreateStarshipAsync(
                                              model, cancellationToken);

                        if (_starship is null)
                        {
                            i++;
                            _errors.Add(i);
                        }
                    }
                }
            }

            var _response = (_errors?.Count ?? 0) == 0;

            return _response;
        }
    }
}

