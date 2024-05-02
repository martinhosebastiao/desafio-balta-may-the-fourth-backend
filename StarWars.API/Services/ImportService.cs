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
            var modelA = await ImportStarshipsAsync(cancellationToken);

            var modelB = await ImportVehiclesAsync(cancellationToken);

            var response = modelA == modelB;

            return response;
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
                    var model = movie.ConvertToMovieModel();

                    var existMovie = await _starWarsRepository
                        .GetMovieByTitleAsync(
                        model.Title,
                        cancellationToken);

                    if (existMovie is null)
                    {
                        var _movie = await _starWarsRepository.CreateMovieAsync(
                                              model,
                                              cancellationToken);

                        if (_movie is null)
                        {
                            i++;
                            _errors.Add(i);
                        }
                        else
                        {
                            // Obter a lista de personagens do filme atual e
                            // adicionar na tabela de relacionamento
                            foreach (var item in movie.Characters)
                            {
                                var _model = new MovieRelationshipModel(_movie.Id);
                                _model.AddCharacters(item);

                                await _starWarsRepository
                                    .CreateRelationalShipAsync(
                                        _model, cancellationToken);
                            }

                            foreach (var item in movie.Planets)
                            {
                                var _model = new MovieRelationshipModel(_movie.Id);
                                _model.AddPlanets(item);

                                await _starWarsRepository
                                    .CreateRelationalShipAsync(
                                        _model, cancellationToken);
                            }

                            foreach (var item in movie.Vehicles)
                            {
                                var _model = new MovieRelationshipModel(_movie.Id);
                                _model.AddVehicles(item);

                                await _starWarsRepository
                                    .CreateRelationalShipAsync(
                                        _model, cancellationToken);
                            }

                            foreach (var item in movie.Starships)
                            {
                                var _model = new MovieRelationshipModel(_movie.Id);
                                _model.AddStarship(item);

                                await _starWarsRepository
                                    .CreateRelationalShipAsync(
                                        _model, cancellationToken);
                            }
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
            string charactersUrl = "https://swapi.py4e.com/api/people/?page=9";

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
                        model.Id,
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
            string planetsUrl = "https://swapi.py4e.com/api/planets/?page=3";

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
                        .GetPlanetByNameAsync(
                        model.Name,
                        cancellationToken);

                    if (existPlanet is null)
                    {
                        var _planet = await _starWarsRepository.CreatePlanetAsync(
                                              model,
                                              cancellationToken);

                        if (_planet is null)
                        {
                            i++;
                            _errors.Add(i);
                        }
                        else
                        {
                            // Obter a lista de personagens do filme atual e
                            // adicionar na tabela de relacionamento
                            foreach (var item in planet.Residents)
                            {
                                var _model = new PlanetRelationshipModel(_planet.Id);
                                _model.AddCharacters(item);

                                await _starWarsRepository
                                    .CreatePlanetRelationshipAsync(
                                        _model, cancellationToken);
                            }

                            foreach (var item in planet.Films)
                            {
                                var _model = new PlanetRelationshipModel(_planet.Id);
                                _model.AddMovies(item);

                                await _starWarsRepository
                                    .CreatePlanetRelationshipAsync(
                                        _model, cancellationToken);
                            }
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
            string vehiclesUrl = "https://swapi.py4e.com/api/vehicles/?page=1";

            var response = await _httpClient.GetFromJsonAsync<VehicleImport>(
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
                        var _vehicles = await _starWarsRepository.CreateVehicleAsync(
                            model, cancellationToken);

                        if (_vehicles is null)
                        {
                            i++;
                            _errors.Add(i);
                        }
                        else
                        {
                            foreach (var item in vehicles.Films)
                            {
                                var _model = new VehicleRelationshipModel(_vehicles.Id);
                                _model.AddMovie(item);

                                await _starWarsRepository
                                    .CreateVehicleRelationalShipAsync(
                                        _model, cancellationToken);
                            }
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
                        .GetStarshipByNameAsync(
                        model.Name,
                        cancellationToken);

                    if (existStarship is null)
                    {
                        var _starship = await _starWarsRepository.CreateStarshipAsync(
                                              model,
                                              cancellationToken);

                        if (_starship is null)
                        {
                            i++;
                            _errors.Add(i);
                        }
                        else
                        {
                            // Obter a lista de personagens do filme atual e
                            // adicionar na tabela de relacionamento
                            foreach (var item in starship.Pilots)
                            {
                                var _model = new StarshipRelationshipModel(_starship.Id);
                                _model.AddCharacters(item);

                                await _starWarsRepository
                                    .CreateStarshipRelationshipAsync(
                                        _model, cancellationToken);
                            }

                            foreach (var item in starship.Films)
                            {
                                var _model = new StarshipRelationshipModel(_starship.Id);
                                _model.AddMovies(item);

                                await _starWarsRepository
                                    .CreateStarshipRelationshipAsync(
                                        _model, cancellationToken);
                            }
                        }
                    }
                }
            }

            var _response = (_errors?.Count ?? 0) == 0;

            return _response;
        }

    }
}

