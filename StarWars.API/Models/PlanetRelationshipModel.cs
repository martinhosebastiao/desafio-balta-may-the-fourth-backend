using System.Text.RegularExpressions;

namespace StarWars.API.Models;

public enum PlanetTargetType : byte
{
    Resident = 1,
    Film = 2
}

public class PlanetRelationshipModel
{ 
    public PlanetRelationshipModel(int planetId)
    {
        PlanetId = planetId;
    }

    public int PlanetRelationshipId { get; private set; }
    public int PlanetId { get; private set; }
    public int TargetId { get; private set; }
    public PlanetTargetType Type { get; private set; }

    public void AddCharacters(string character)
    {
        Type = PlanetTargetType.Resident;
        TargetId = ExtractIdFromUrl(character);
    }

    public void AddMovies(string movie)
    {
        Type = PlanetTargetType.Film;
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
