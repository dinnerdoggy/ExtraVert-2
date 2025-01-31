using ExtraVert;
using System.Numerics;
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
                $"{PlantDetails(plant)} in {plant.City} has sold for {plant.AskingPrice}"
                :
                $"{PlantDetails(plant)} in {plant.City} is available for {plant.AskingPrice} until {plant.AvailableUntil}";
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
                    string i = $"{PlantDetails(plant)} in {plant.City} is available for {plant.AskingPrice} until {plant.AvailableUntil}.";
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
                Console.WriteLine($"You have adopted {PlantDetails(plant)}. It is now marked as sold.");
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

    public static void ViewStats(List<Plant> plants)
    {
        Console.WriteLine("======Stats======");

        // Loop to find lowest price plant
        decimal lowest = plants[0].AskingPrice;
        string lowestName = plants[0].Species;
        foreach (var plant in plants)
        {
            if (plant.AskingPrice < lowest)
            {
                lowest = plant.AskingPrice;
                lowestName = PlantDetails(plant);
            }
            else
            {
                continue;
            }

        }

        // Loop to find number of plants available
        int count = 0;
        foreach (var plant in plants)
        {
            if (plant.Sold == false && plant.AvailableUntil > DateTime.Now)
            {
                count++;
            }
        }

        // Loop to find plant with highest light needs
        decimal highestNeed = plants[0].LightNeeds;
        string highestNeedName = plants[0].Species;
        foreach (var plant in plants)
        {
            if (plant.LightNeeds > highestNeed)
            {
                highestNeed = plant.LightNeeds;
                highestNeedName = plant.Species;
            }
            else
            {
                continue;
            }

        }

        // Loop to find average light needs of all plants
        int sumOfNeeds = 0;
        int countForAvg = 0;
        int average = 0;
        foreach (var plant in plants)
        {
            countForAvg++;
            sumOfNeeds += plant.LightNeeds;
        }
        average = sumOfNeeds / countForAvg;

        // Loop to find percentage of plants adopted - part/whole x 100 = percentage
        double plantsAdopted = 0;
        int totalPlantsPerc = 0;
        foreach (var plant in plants)
        {
            ++totalPlantsPerc;

            if (plant.Sold == true)
            {
                ++plantsAdopted;
            }
            else
            {
                continue;
            }
        }
        var percAdopted = (plantsAdopted / totalPlantsPerc) * 100;

        Console.WriteLine($"Lowest price plant: {lowestName}");
        Console.WriteLine($"Total plants available: {count}");
        Console.WriteLine($"Plant with greatest light needs: {highestNeedName}");
        Console.WriteLine($"Average of light needs for all plants: {average}");
        Console.WriteLine($"Percentage of plants already adopted: {percAdopted}%");
    }

    public static string PlantDetails(Plant plant)
    {
        string plantString = plant.Species;

        return plantString;

    }
}