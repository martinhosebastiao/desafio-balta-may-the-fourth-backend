namespace StarWars.API.Models.Imports;

public class VehicleImport
{
    public int count { get; set; }
    public object next { get; set; }
    public object previous { get; set; }
    public List<VehicleResult> Results { get; set; }

}

public class VehicleResult
{
    public VehicleResult() { }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string? cost_in_credits { get; set; }
    public string Length { get; set; }
    public string max_atmosphering_speed { get; set; }
    public string? Crew { get; set; }
    public string? passengers { get; set; }
    public string cargo_capacity { get; set; }
    public string Consumables { get; set; }
    public string vehicle_class { get; set; }
    public List<string> Films { get; set; }


    public VehicleModel ConvertToModel()
    {
        return new VehicleModel
        {
            Name = Name,
            Model = Model,
            Manufacturer = Manufacturer,
            CostInCredits = cost_in_credits,
            Length = Length,
            MaxSpeed = max_atmosphering_speed,
            Crew = Crew,
            Passengers = passengers,
            CargoCapacity = cargo_capacity,
            Consumables = Consumables,
            Class = vehicle_class,

        };
    }
}