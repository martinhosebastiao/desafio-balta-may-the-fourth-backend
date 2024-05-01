using System.Text.RegularExpressions;

namespace StarWars.API.Models.Imports;

public class CharacterImport
{
    public string Message { get; set; }
    public List<CharacterResult> Results { get; set; }
}

public class CharacterResult
{
    public string Name { get; set; }
    public string Height { get; set; }
    public string Mass { get; set; }
    public string Hair_Color { get; set; }
    public string Skin_Color { get; set; }
    public string Eye_Color { get; set; }
    public string Birth_Year { get; set; }
    public string Gender { get; set; }
    public string Planet { get; set; }
    public List<string> Movies { get; set; }

    public CharacterModel ConvertToModel()
    {
        return new CharacterModel
        {
            Name = Name,
            Height = Height,
            Mass = Mass,
            HairColor = Hair_Color,
            SkinColor = Skin_Color,
            EyeColor = Eye_Color,
            BirthYear = Birth_Year,
            Gender = Gender
        };
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



