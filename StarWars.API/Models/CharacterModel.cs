﻿namespace StarWars.API.Models;

public sealed class CharacterModel
{
    public CharacterModel() {
        Planet = new PlanetModel();
        Movies = new List<MovieModel>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Height { get; set; }
    public string Mass { get;  set; }
    public string HairColor { get; set; }
    public string SkinColor { get; set; }
    public string EyeColor { get; set; }
    public string BirthYear { get; set; }
    public string Gender { get; set; }
    public PlanetModel Planet { get; set; }
    public List<MovieModel> Movies { get; set; }
}
