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

    public static void DelistPlant(List<Plant> plants)
    {
        Options.ListPlants(plants);
        Console.WriteLine("\nEnter the number of the plant you would like to delist:");
        var choice = int.Parse(Console.ReadLine()) - 1;
        var name = plants[choice].Species;
        plants.RemoveAt(choice);
        Console.Clear();
        Options.ListPlants(plants);
        Console.WriteLine($"\n{name} has been delisted!");
    }

    public static void PlantOfTheDay(List<Plant> plants)
    {
        Random random = new Random();
        int randomInteger = random.Next(1, plants.Count);
        Console.WriteLine($"\n\tPlant of the Day!\n\t=================\n\tName:\t\t\t{plants[randomInteger].Species},\n\tLocation:\t\t{plants[randomInteger].City},\n\tLight needs (1-5):\t{plants[randomInteger].LightNeeds},\n\tPrice:\t\t\t{plants[randomInteger].AskingPrice}");
    }
}