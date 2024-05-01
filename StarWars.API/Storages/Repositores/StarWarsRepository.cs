using Microsoft.EntityFrameworkCore;
using StarWars.API.Models;
using StarWars.API.Storages.Datas;

namespace StarWars.API.Storages.Repositores
{
    public class StarWarsRepository : IStarWarsRepository
    {
        private readonly StarWarsContext _context;

        public StarWarsRepository(StarWarsContext context)
        {
            _context = context;
        }

        public async Task<MovieModel?> CreateMovieAsync(
            MovieModel model,
            CancellationToken cancellationToken = default)
        {
            _context.Movies.Add(model);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result == 0 ? null : model;
        }

        public async Task<List<MovieModel>?> GetMoviesAsync(
            CancellationToken cancellationToken = default)
        {
            var response = await (from movie in _context.Movies.AsNoTracking()
                                  select new
                                  {
                                      movie,
                                      persons = (from rel in _context.MovieRelationships
                                                 join person in _context.Characters on rel.TargetId equals person.Id
                                                 where rel.MovieId == movie.Id && rel.Type == TargetType.Character
                                                 select person
                                                 ).ToList(),
                                      planets = (from rel in _context.MovieRelationships
                                                 join planet in _context.Planets on rel.TargetId equals planet.Id
                                                 where rel.MovieId == movie.Id && rel.Type == TargetType.Planet
                                                 select planet
                                                 ).ToList(),
                                      vehicles = (from rel in _context.MovieRelationships
                                                  join vehicle in _context.Vehicles on rel.TargetId equals vehicle.Id
                                                  where rel.MovieId == movie.Id && rel.Type == TargetType.Vehicle
                                                  select vehicle
                                                 ).ToList(),
                                      starship = (from rel in _context.MovieRelationships
                                                  join starship in _context.Starships on rel.TargetId equals starship.Id
                                                  where rel.MovieId == movie.Id && rel.Type == TargetType.Starship
                                                  select starship
                                                 ).ToList()
                                  })
                                  .AsNoTracking()
                                  .ToListAsync(cancellationToken: cancellationToken);

            var _movies = new List<MovieModel>();
            int movieContol = 0;

            foreach (var item in response)
            {
                if (movieContol != item?.movie?.Id && item?.movie != null)
                {
                    if (item.persons.Count > 0)
                    {
                        item.movie?.Characters?.AddRange(item.persons);
                    }

                    if (item.planets.Count > 0)
                    {
                        item.movie?.Planets?.AddRange(item.planets);
                    }

                    if (item.vehicles.Count > 0)
                    {
                        item.movie?.Vehicles?.AddRange(item.vehicles);
                    }

                    if (item.starship.Count > 0)
                    {
                        item.movie?.Starships?.AddRange(item.starship);
                    }

                    _movies.Add(item.movie!);

                    movieContol = item.movie.Id;
                }
            }

            return _movies;
        }

        public async Task<MovieModel?> GetMovieByIdAsync(
            int movieId, CancellationToken cancellationToken = default)
        {
            var response = await _context.Movies.Where(x => x.Id == movieId)
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }

        public async Task<MovieModel?> GetMovieByTitleAsync(string title,
            CancellationToken cancellationToken = default)
        {
            var response = await _context.Movies.Where(x => x.Title == title)
                 .FirstOrDefaultAsync(cancellationToken);

            return response;
        }

        public async Task<List<CharacterModel>?> GetCharactersAsync(
            CancellationToken cancellationToken = default)
        {
            var response = await _context.Characters.ToListAsync(cancellationToken);

            return response;
        }

        public async Task<CharacterModel?> GetCharacterByIdAsync(
            int characterId,
            CancellationToken cancellationToken = default)
        {
            var response = await _context.Characters.Where(x => x.Id == characterId)
                 .FirstOrDefaultAsync(cancellationToken);

            return response;
        }

        public async Task<CharacterModel?> CreateCharacterAsync(CharacterModel model, CancellationToken cancellationToken = default)
        {
            _context.Characters.Add(model);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result == 0 ? null : model;
        }

        public async Task<PlanetModel?> GetPlanetByIdAsync(
            int planetId,
            CancellationToken cancellationToken = default)
        {
            var response = await _context.Planets.Where(x => x.Id == planetId)
                 .FirstOrDefaultAsync(cancellationToken);

            return response;
        }

        public async Task<PlanetModel?> CreatePlanetAsync(PlanetModel model, CancellationToken cancellationToken = default)
        {
            _context.Planets.Add(model);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result == 0 ? null : model;
        }

        public async Task<List<VehicleModel>?> GetVehicleAsync(
            CancellationToken cancellationToken = default)
        {
            var response = await _context.Vehicles.ToListAsync(cancellationToken);

            return response;
        }

        public async Task<List<PlanetModel>?> GetPlanetsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _context.Planets.ToListAsync(cancellationToken);

            return response;
        }

        public async Task<StarshipModel?> GetStarshipByIdAsync(
           int starshipId,
           CancellationToken cancellationToken = default)
        {
            var response = await _context.Starships.Where(x => x.Id == starshipId)
                 .FirstOrDefaultAsync(cancellationToken);

            return response;
        }

        public async Task<StarshipModel?> CreateStarshipAsync(StarshipModel model, CancellationToken cancellationToken = default)
        {
            _context.Starships.Add(model);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result == 0 ? null : model;
        }

        public async Task<VehicleModel?> GetVehicleByIdAsync(
            int Id,
            CancellationToken cancellationToken = default)
        {
            var response = await _context.Vehicles.Where(x => x.Id == Id)
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }

        public async Task<VehicleModel?> CreateVehicleAsync(VehicleModel model,
            CancellationToken cancellationToken = default)
        {
            _context.Vehicles.Add(model);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result == 0 ? null : model;
        }

        public async Task<MovieRelationshipModel?> CreateRelationalShipAsync(
            MovieRelationshipModel model,
            CancellationToken cancellationToken = default)
        {
            _context.MovieRelationships.Add(model);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result == 0 ? null : model;
        }

        public async Task<VehicleRelationshipModel?> CreateVehicleRelationalShipAsync(VehicleRelationshipModel model, CancellationToken cancellationToken = default)
        {
            _context.VehicleRelationships.Add(model);
            var result = await _context.SaveChangesAsync(cancellationToken);

            return result == 0 ? null : model;
        }
    }
}

