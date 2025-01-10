﻿using ExtraVert;
using PostPlant;


Plant plant1 = new Plant("Thyme", 5, 5.00m, "Nashville", 37214, false);
Plant plant2 = new Plant("Basil", 5, 5.00m, "Clarksville", 37130, true);
Plant plant3 = new Plant("Marjeewanna", 5, 15.00m, "Classified Location", 55555, true);
Plant plant4 = new Plant("Tomato", 4, 3.00m, "Walmart", 37042, false);
Plant plant5 = new Plant("Habenero", 5, 1.00m, "Murfreesboro", 37130, true);

var plants = new List<Plant> { plant1, plant2, plant3, plant4, plant5 };

bool exit = false;

while (!exit)
{
    // Display the menu
    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("========== Main Menu ==========");
        Console.WriteLine("a. Display all plants");
        Console.WriteLine("b. Post a plant to be adopted");
        Console.WriteLine("c. Adopt a plant");
        Console.WriteLine("d. Delist a plant");
        Console.WriteLine("e. Exit the application");
        Console.WriteLine("===============================");
        Console.Write("Enter your choice (a-b): ");
    }

    DisplayMenu();

    // Read user input
    string choice = Console.ReadLine();

    // Handle user input with a switch statement
    switch (choice)
    {
        case "a":
            Console.Clear();
            PerformOptionA();
            break;

        case "b":
            Console.Clear();
            PerformOptionB();
            break;

        case "c":
            Console.Clear();
            PerformOptionC();
            break;

        case "d":
            Console.Clear();
            PerformOptionD();
            break;

        case "e":
            Console.Clear();
            Console.WriteLine("So long my friend ♥");
            Console.ReadLine();
            Console.Clear();
            exit = true;
            break;

        default:
            Console.Clear();
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    // Pause before redisplaying the menu
    if (!exit)
    {
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}

void PerformOptionA()
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

void PerformOptionB()
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

static void PerformOptionC()
{
    Console.WriteLine("Chose Adopt a plant.");
    // Add logic for Option c
}

static void PerformOptionD()
{
    Console.WriteLine("Chose Delist a plant.");
    // Add logic for Option d
}

// Console.WriteLine("\n\nWhat is up my boofus?\n\n\tI got some plants for yo bitch ass...\n");

//foreach (var plant in plants)
//{
//    Console.WriteLine($"\t\t{plant.Species}, {plant.AskingPrice}\n");
//}

//Console.WriteLine("\n");