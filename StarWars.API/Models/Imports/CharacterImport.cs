using System.Text.RegularExpressions;

namespace StarWars.API.Models.Imports;

public class CharacterImport
{
    public int count { get; set; }
    public object next { get; set; }
    public object previous { get; set; }
    public List<CharacterResult> Results { get; set; }
}

public class CharacterResult
{
    public CharacterResult() { }
    public string Name { get; set; }
    public string Height { get; set; }
    public string Mass { get; set; }
    public string Hair_Color { get; set; }
    public string Skin_Color { get; set; }
    public string Eye_Color { get; set; }
    public string Birth_Year { get; set; }
    public string Gender { get; set; }
    public string Homeworld { get; set; }
    public List<string> Films { get; set; }

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
}



