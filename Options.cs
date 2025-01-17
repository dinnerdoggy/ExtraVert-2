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

        Console.WriteLine("Enter expiration date for this plant...\n\tEnter the date in the format: mm/dd/yyyy");
        try
        {
            var input = Console.ReadLine();
            var date = DateTime.Parse(input);

            var newPlant = new Plant(species, LightNeeds, AskingPrice, City, Zip, false, date);
            plants.Add(newPlant);
        }
        catch
        {
            Console.WriteLine("Wrong format!");
        }

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
                $"{plant.Species} in {plant.City} is available for {plant.AskingPrice} until {plant.AvailableUntil}";
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
            } else if (plant.AvailableUntil > DateTime.Now)
                {
                    plantsForSale.Add(plant);

                    // Process the plant if it is not sold
                    string i = $"{plant.Species} in {plant.City} is available for {plant.AskingPrice} until {plant.AvailableUntil}.";
                    Console.WriteLine($"{++count}. {i}");
                }
            else
            {
                continue;
            }

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
        int randomInteger = random.Next(0, plants.Count);

        // keep rolling the dice until we get 
        do
        {
            randomInteger = random.Next(0, plants.Count);
        }
        while (plants[randomInteger].Sold == true);

        Console.WriteLine($"\n\tPlant of the Day!\n\t=================\n\tName:\t\t\t{plants[randomInteger].Species},\n\tLocation:\t\t{plants[randomInteger].City},\n\tLight needs (1-5):\t{plants[randomInteger].LightNeeds},\n\tPrice:\t\t\t{plants[randomInteger].AskingPrice}");
    }

    public static void SearchByLightNeeds(List<Plant> plants)
    {
        Console.WriteLine("To see all plants within a light theshold,\nenter the maximum light needs (1-5)\nthat you are able to provide\nfor a plant. 1 being the lowest\n5 being the highest.\n");
        var choice = int.Parse(Console.ReadLine());

        for (int i = 0; i < plants.Count; i++) 
        {
            if (plants[i].LightNeeds <= choice)
            {
                Console.WriteLine(plants[i].Species);
            }
        }
    }
}