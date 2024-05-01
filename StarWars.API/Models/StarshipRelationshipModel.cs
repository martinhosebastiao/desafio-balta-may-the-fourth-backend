using System.Text.RegularExpressions;

namespace StarWars.API.Models;

public enum StarshipTargetType : byte
{
    Pilot = 1,
    Film = 2
}

public class StarshipRelationshipModel
{
    public StarshipRelationshipModel(int starshipId)
    {
        StarshipId = starshipId;
    }

    public int StarshipRelationshipId { get; set; }
    public int StarshipId { get; set; }
    public int TargetId { get; private set; }
    public StarshipTargetType Type { get; private set; }

    public void AddCharacters(string character)
    {
        Type = StarshipTargetType.Pilot;
        TargetId = ExtractIdFromUrl(character);
    }

    public void AddMovies(string movie)
    {
        Type = StarshipTargetType.Film;
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
