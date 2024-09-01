using System;
using System.Collections.Generic;

namespace VehicleRentalSystem.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public string? Type { get; set; }

    public decimal RatePerDay { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
