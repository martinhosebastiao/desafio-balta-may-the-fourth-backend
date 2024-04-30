namespace StarWars.API.Models
{
    public class MovieModel
    {
        public MovieModel()
        {
            Characters = new List<CharacterModel>();
            Planets = new List<PlanetModel>();
            Vehicles = new List<VehicleModel>();
            Starships = new List<StarshipModel>();
        }

        public int Id { get; set; }
        public required string Title { get; set; }
        public int EpisodeId { get; set; }
        public string? Director { get; set; }
        public required string Producer { get; set; }
        public string? ReleaseDate { get; set; }
        public string? OpeningCrawl { get; set; }
        public string? Url { get; set; }

        public List<CharacterModel>? Characters { get; set; }
        public List<PlanetModel>? Planets { get; set; }
        public List<VehicleModel>? Vehicles { get; set; }
        public List<StarshipModel>? Starships { get; set; }

    }
}

