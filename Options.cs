using ExtraVert;
namespace PostPlant;

public class Options
{
    public static void PostPlant(List<Plant> plants)
    {
        Console.WriteLine("Please enter the species name:");
        string species = Console.ReadLine();

        Console.Write("Enter light needs 1-5:");
        var LightNeeds = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter asking price:");
        var AskingPrice = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter City: ");
        var City = Console.ReadLine();

        Console.WriteLine("Enter zip code: ");
        var Zip = int.Parse(Console.ReadLine());

        var newPlant = new Plant(species, LightNeeds, AskingPrice, City, Zip, false);
        plants.Add(newPlant);
    }

    public static void ListPlants(List<Plant> plants)
    {
        int count = 0;
        foreach (var plant in plants)
        {
            string i = plant.Sold
                ?
                $"{plant.Species} in {plant.City} has sold for {plant.AskingPrice}"
                :
                $"{plant.Species} in {plant.City} is available for {plant.AskingPrice}";
            Console.WriteLine($"{++count}. {i}");
        }
    }

    public static void AdoptPlant(List<Plant> plants)
    {
        int count = 0;
        var plantsForSale = new List<Plant> { };

        foreach (var plant in plants)
        {
            // Skip the iteration if the plant is sold
            if (plant.Sold)
            {
                continue;
            }

            plantsForSale.Add(plant);

            // Process the plant if it is not sold
            string i = $"{plant.Species} in {plant.City} is available for {plant.AskingPrice}";
            Console.WriteLine($"{++count}. {i}");
        }

        Console.WriteLine("Enter the number for the plant you would like to adopt: ");
        var choice = int.Parse(Console.ReadLine()) - 1;
        var choiceName = plantsForSale[choice].Species;

        // Validate user input
        if (choice < 0 || choice >= plantsForSale.Count)
        {
            Console.WriteLine("Invalid choice. Please try again.");
            return;
        }

        var selectedPlant = plantsForSale[choice];

        // Update the 'Sold' property of the matching plant in the original list
        foreach (var plant in plants)
        {
            if (plant == selectedPlant)
            {
                plant.Sold = true;
                Console.WriteLine($"You have adopted {plant.Species}. It is now marked as sold.");
                break;
            }
        }
    }
}