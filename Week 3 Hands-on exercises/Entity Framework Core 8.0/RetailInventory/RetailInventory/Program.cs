using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            Console.WriteLine("----- All Products -----");
            var products = await context.Products
                                        .Include(p => p.Category)
                                        .ToListAsync();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - ₹{p.Price} (Category: {p.Category?.Name})");
            }

            Console.WriteLine("\n----- Find Product by ID (1) -----");
            var productById = await context.Products
                                           .Include(p => p.Category)
                                           .FirstOrDefaultAsync(p => p.Id == 1);
            Console.WriteLine(productById != null
                ? $"Found: {productById.Name} - ₹{productById.Price}"
                : "Product not found.");

            Console.WriteLine("\n----- Find Expensive Product (Price > ₹50,000) -----");
            var expensive = await context.Products
                                         .Include(p => p.Category)
                                         .FirstOrDefaultAsync(p => p.Price > 50000);

            Console.WriteLine(expensive != null
                ? $"Expensive: {expensive.Name} - ₹{expensive.Price}"
                : "No expensive product found.");
        }
    }
}
