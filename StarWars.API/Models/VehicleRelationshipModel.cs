using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StarWars.API.Models
{

    public enum VehicleTargetType : byte
    {
        Film = 1
    }

    public class VehicleRelationshipModel
    {
        public VehicleRelationshipModel(int vehicleId)
        {
            VehicleId = vehicleId;
        }

        public int VehicleRelationshipId { get; private set; }
        public int VehicleId { get; private set; }
        public int TargetId { get; private set; }
        public VehicleTargetType Type { get; private set; }




        public void AddMovies(string movie)
        {
            Type = VehicleTargetType.Film;
            TargetId = ExtractIdFromUrl(movie);
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