using ExtraVert;

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
    Console.Clear();
    Console.WriteLine("========== Main Menu ==========");
    Console.WriteLine("a. Display all plants");
    Console.WriteLine("b. Post a plant to be adopted");
    Console.WriteLine("c. Adopt a plant");
    Console.WriteLine("d. Delist a plant");
    Console.WriteLine("e. Exit the application");
    Console.WriteLine("===============================");
    Console.Write("Enter your choice (a-b): ");

    // Read user input
    string choice = Console.ReadLine();

    // Handle user input with a switch statement
    switch (choice)
    {
        case "a":
            throw new NotImplementedException("Display all plants");
            //Console.WriteLine("Chose Display all plants.");
            //PerformOptionA();
            break;

        case "b":
            PerformOptionB();
            break;

        case "c":
            PerformOptionC();
            break;

        case "d":
            PerformOptionD();
            break;

        case "e":
            Console.WriteLine("So long my friend ♥");
            exit = true;
            break;

        default:
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

    static void PerformOptionA()
{
    Console.WriteLine("Performing action for Option a...");
    // Add logic for Option a
}

static void PerformOptionB()
{
    Console.WriteLine("Chose Post a plant to be adopted.");
    // Add logic for Option b
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