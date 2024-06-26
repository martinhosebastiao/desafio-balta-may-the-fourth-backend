﻿namespace StarWars.API.Models.Imports;

public class PlanetImport
{
    public int count { get; set; }
    public object next { get; set; }
    public object previous { get; set; }
    public List<PlanetResult> Results { get; set; }
}

public class PlanetResult
{
    public PlanetResult() { }
    public string Name { get; set; }
    public string Rotation_Period { get; set; }
    public string Orbital_Period { get; set; }
    public string Diameter { get; set; }
    public string Climate { get; set; }
    public string Gravity { get; set; }
    public string Terrain { get; set; }
    public string Surface_Water { get; set; }
    public string Population { get; set; }
    public List<string> Residents { get; set; }
    public List<string> Films { get; set; }

    public PlanetModel ConvertToModel()
    {
        return new PlanetModel
        {
            Name = Name,
            RotationPeriod = Rotation_Period,
            OrbitalPeriod = Orbital_Period,
            Diameter = Diameter,
            Climate = Climate,
            Gravity = Gravity,
            Terrain = Terrain,
            SurfaceWater = Surface_Water,
            Population = Population,
        };
    }
}
