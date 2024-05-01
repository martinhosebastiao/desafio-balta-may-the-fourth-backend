using System;
using System.Text.RegularExpressions;
using StarWars.API.Common.Enums;
using StarWars.API.Common.Utilities;

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
            TargetId = Extract.IdFromUrl(movie);
        }

        
    }
}