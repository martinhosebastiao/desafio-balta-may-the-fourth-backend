using System.Text.RegularExpressions;

namespace StarWars.API.Models;

public enum CharacterTargetType : byte
{
    Homeworld = 1,
    Film = 2
}

public class CharacterRelationshipModel
{
    public CharacterRelationshipModel(int characterId)
    {
        CharacterId = characterId;
    }

    public int CharacterRelationshipId { get; private set; }
    public int CharacterId { get; private set; }
    public int TargetId { get; private set; }
    public CharacterTargetType Type { get; private set; }

    public void AddPlanet(string planet)
    {
        Type = CharacterTargetType.Homeworld;
        TargetId = ExtractIdFromUrl(planet);
    }

    public void AddMovies(string movie)
    {
        Type = CharacterTargetType.Film;
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
