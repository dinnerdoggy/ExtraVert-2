namespace ExtraVert;

public class Plant
{
    public string Species;
    public int LightNeeds;
    public decimal AskingPrice;
    public string City;
    public int Zip;
    public bool Sold;

    public Plant(string species, int lightneeds, decimal askingprice, string city, int zip, bool sold)
    {
        Species = species;
        LightNeeds = lightneeds;
        AskingPrice = askingprice;
        City = city;
        Zip = zip;
        Sold = sold;
    }
}
