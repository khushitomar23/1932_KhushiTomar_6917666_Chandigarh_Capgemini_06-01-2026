using System;
using System.Collections.Generic;
using System.Linq;

public interface IRealEstateListing
{
    int ID { get; set; }
    string Title { get; set; }
    string Description { get; set; }
    int Price { get; set; }
    string Location { get; set; }
}

public class RealEstateListing : IRealEstateListing
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Location { get; set; }
}

public class RealEstateApp
{
    private List<IRealEstateListing> listings = new List<IRealEstateListing>();

    public void AddListing(IRealEstateListing listing)
    {
        listings.Add(listing);
    }

    public void RemoveListing(int listingID)
    {
        listings.RemoveAll(l => l.ID == listingID);
    }

    public void UpdateListing(IRealEstateListing updateListing)
    {
        var listing = listings.FirstOrDefault(l => l.ID == updateListing.ID);
        if (listing != null)
        {
            listing.Title = updateListing.Title;
            listing.Description = updateListing.Description;
            listing.Price = updateListing.Price;
            listing.Location = updateListing.Location;
        }
    }

    public List<IRealEstateListing> GetListings()
    {
        return listings;
    }

    public List<IRealEstateListing> GetListingsByLocation(string location)
    {
        return listings.Where(l => l.Location.ToLower() == location.ToLower()).ToList();
    }

    public List<IRealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
    {
        return listings.Where(l => l.Price >= minPrice && l.Price <= maxPrice).ToList();
    }
}

class Program
{
    static void Main()
    {
        RealEstateApp app = new RealEstateApp();

        app.AddListing(new RealEstateListing { ID = 1, Title = "Villa", Description = "Luxury villa", Price = 500000, Location = "Delhi" });
        app.AddListing(new RealEstateListing { ID = 2, Title = "Apartment", Description = "2BHK apartment", Price = 200000, Location = "Mumbai" });

        Console.WriteLine("All Listings:");
        foreach (var l in app.GetListings())
        {
            Console.WriteLine(l.Title + " - " + l.Location + " - " + l.Price);
        }

        Console.WriteLine("\nListings in Delhi:");
        foreach (var l in app.GetListingsByLocation("Delhi"))
        {
            Console.WriteLine(l.Title + " - " + l.Price);
        }

        Console.WriteLine("\nListings between 100000 and 400000:");
        foreach (var l in app.GetListingsByPriceRange(100000, 400000))
        {
            Console.WriteLine(l.Title + " - " + l.Price);
        }
    }
}