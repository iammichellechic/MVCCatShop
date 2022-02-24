using Bogus;
using Microsoft.EntityFrameworkCore;

namespace SkysMvcCatShop.Data;

public class DataInitializer
{
    private readonly ApplicationDbContext _context;

    public DataInitializer(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        _context.Database.Migrate();

        SeedProducts();

    }

    private void SeedProducts()
    {
        while (_context.Products.Count() < 100)
        {
            _context.Products.Add(GenerateProduct());
            _context.SaveChanges();
        }
    }


    private Product GenerateProduct()
    {
        var testUser = new Faker<Product>()
            .StrictMode(true)
            .RuleFor(e => e.Id, f => 0)
            .RuleFor(e => e.Name, (f, u) => f.Commerce.Product())
            .RuleFor(e => e.Color, (f, u) => f.Commerce.Color())
            .RuleFor(e => e.Created, (f, u) => f.Date.Past())
            .RuleFor(e => e.LastBought, (f, u) => f.Date.Recent())
            .RuleFor(e => e.Ean13, (f, u) => f.Commerce.Ean13())
            .RuleFor(e => e.PopularityPercent, (f, u) => f.Random.Number(0, 100))
            .RuleFor(e => e.Price, (f, u) => Convert.ToDecimal(f.Commerce.Price()));

        var person = testUser.Generate(1).First();
        return person;
    }



}