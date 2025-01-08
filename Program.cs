using ExtraVert;
using System.Collections.Generic;

Plant plant1 = new Plant("Thyme", 5, 5.00m, "Nashville", 37214, false);
Plant plant2 = new Plant("Basil", 5, 5.00m, "Clarksville", 37130, true);

var plants = new List<Plant> { plant1, plant2 };

foreach (var plant in plants)
{
    Console.WriteLine(plant.Species);
}
