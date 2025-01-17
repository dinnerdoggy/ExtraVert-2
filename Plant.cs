namespace ExtraVert;

public class Plant
{
   public string Species { get; set; }
   public int LightNeeds { get; set; }
   public decimal AskingPrice { get; set; }
   public string City { get; set; }
   public int Zip {  get; set; }
   public bool Sold { get; set; }
   public DateTime AvailableUntil { get; set; }

   public Plant(string species, int lightneeds, decimal askingprice, string city, int zip, bool sold, DateTime availableUntil)
    {
        Species = species;
        LightNeeds = lightneeds;
        AskingPrice = askingprice;
        City = city;
        Zip = zip;
        Sold = sold;
        AvailableUntil = availableUntil;
    }
}
