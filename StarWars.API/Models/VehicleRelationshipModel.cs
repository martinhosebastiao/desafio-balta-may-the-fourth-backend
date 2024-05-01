using System;
using System.Text.RegularExpressions;

namespace StarWars.API.Models
{
    public class VehicleRelationshipModel
    {
        public VehicleRelationshipModel(int vehicleId)
        {
            VehicleId = vehicleId;
        }

        public int VehicleRelationshipId { get; private set; }
        public int VehicleId { get; private set; }
        public int TargetId { get; private set; }
        public TargetType Type { get; private set; }

        public void AddMovie(string movie)
        {
            Type = TargetType.Movie;
            TargetId = ExtractIdFromUrl(movie);
        }

        static int ExtractIdFromUrl(string? input)
        {
            if (input is null)
            {
                return 0;
            }

            input = input?.Replace("https://swapi.py4e.com/api/starships/", "");

            // Cria um padrão regex para encontrar apenas dígitos numéricos
            Regex regex = new Regex(@"\d+");

            var result = regex.Matches(input!).FirstOrDefault();

            // Extrai os números da string de entrada
            var IdExtraido = int.Parse(result?.Value ?? "0");

            return IdExtraido;
        }
    }
}