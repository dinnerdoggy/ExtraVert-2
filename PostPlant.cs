using ExtraVert;
namespace PostPlant


{
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
    }

}