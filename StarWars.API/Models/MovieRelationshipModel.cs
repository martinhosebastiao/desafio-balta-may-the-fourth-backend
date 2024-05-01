using System;
using System.Text.RegularExpressions;

namespace StarWars.API.Models
{
    public enum TargetType : byte
    {
        Character = 1,
        Planet = 2,
        Starship = 3,
        Vehicle = 4
    }

    public class MovieRelationshipModel
    {
        public MovieRelationshipModel(int movieId)
        {
            MovieId = movieId;
        }

        public int MovieRelationshipId { get; private set; }
        public int MovieId { get; private set; }
        public int TargetId { get; private set; }
        public TargetType Type { get; private set; }

        public void AddCharacters(string character)
        {
            Type = TargetType.Character;
            TargetId = ExtractIdFromUrl(character);
        }

        public void AddPlanets(string planet)
        {
            Type = TargetType.Planet;
            TargetId = ExtractIdFromUrl(planet);
        }

        public void AddStarship(string starship)
        {
            Type = TargetType.Starship;
            TargetId = ExtractIdFromUrl(starship);
        }

        public void AddVehicles(string vehicle)
        {
            Type = TargetType.Vehicle;
            TargetId = ExtractIdFromUrl(vehicle);
        }

        static int ExtractIdFromUrl(string? input)
        {
            if (input is null)
            {
                return 0;
            }

            input = input?.Replace("https://swapi.py4e.com/api/", "");

            // Cria um padrão regex para encontrar apenas dígitos numéricos
            Regex regex = new Regex(@"\d+");

            var result = regex.Matches(input!).FirstOrDefault();

            // Extrai os números da string de entrada
            var IdExtraido = int.Parse(result?.Value ?? "0");

            return IdExtraido;
        }

    }
}