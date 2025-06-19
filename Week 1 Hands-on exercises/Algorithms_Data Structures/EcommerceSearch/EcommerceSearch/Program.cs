using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product(101, "Laptop", "Electronics"),
            new Product(205, "Shoes", "Fashion"),
            new Product(150, "Phone", "Electronics"),
            new Product(110, "Watch", "Accessories")
        };

        Console.WriteLine("LINEAR SEARCH (by ProductId = 150):");
        Product foundLinear = LinearSearch(products, 150);
        PrintResult(foundLinear);

        Product[] sortedProducts = products.OrderBy(p => p.ProductId).ToArray();

        Console.WriteLine("\nBINARY SEARCH (by ProductId = 150):");
        Product foundBinary = BinarySearch(sortedProducts, 150);
        PrintResult(foundBinary);

        Console.ReadLine(); 
    }

    // Linear Search: O(n)
    static Product LinearSearch(Product[] products, int targetId)
    {
        foreach (Product p in products)
        {
            if (p.ProductId == targetId)
                return p;
        }
        return null;
    }

    // Binary Search: O(log n)
    static Product BinarySearch(Product[] products, int targetId)
    {
        int left = 0, right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (products[mid].ProductId == targetId)
                return products[mid];
            else if (products[mid].ProductId < targetId)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }

    static void PrintResult(Product product)
    {
        if (product != null)
            Console.WriteLine($"Found: {product.ProductName} in category '{product.Category}'");
        else
            Console.WriteLine("Product not found.");
    }
}
