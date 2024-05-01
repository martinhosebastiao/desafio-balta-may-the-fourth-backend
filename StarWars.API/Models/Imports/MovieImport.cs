using System.Text.Json.Serialization;

namespace StarWars.API.Models.Imports
{
    public class MovieImport
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<MovieResult> Results { get; set; }
    }

    public class MovieResult
    {
        public MovieResult(){}

        public int Id { get; set; }
        public string Title { get; set; }
        public int Episode_id { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Release_date { get; set; }
        public string Opening_Crawl { get; set; }
        public string Url { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public List<string> Characters { get; set; }
        public List<string> Planets { get; set; }
        public List<string> Starships { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Species { get; set; }

        public MovieModel ConvertToMovieModel()
        {
            var model = new MovieModel()
            {
                Id = Id,
                Title = Title,
                EpisodeId = Episode_id,
                Director = Director,
                Producer = Producer,
                ReleaseDate = Release_date,
                OpeningCrawl = Opening_Crawl,
                Url = Url
            };

            return model;
        }
    }

}

