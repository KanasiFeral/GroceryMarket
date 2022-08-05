using GroceryMarket.Classes;
using GroceryMarket.ModelsDTO;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ProductCode = "A",
                    Price = 1.25,
                    IsWholesale = true,
                    WholesalePrice = 3.00,
                    WholesaleCount = 3                    
                },
                new Product()
                {
                    ProductCode = "B",
                    Price = 4.25,
                    IsWholesale = false,
                    WholesalePrice = 0.00,
                    WholesaleCount = 0                    
                },
                new Product()
                {
                    ProductCode = "C",
                    Price = 1.00,
                    IsWholesale = true,
                    WholesalePrice = 5.00,
                    WholesaleCount = 6
                }
            };

            Product product = new Product()
            {
                ProductCode = "D",
                Price = 0.75,
                IsWholesale = false,
                WholesalePrice = 0.00,
                WholesaleCount = 0
            };

            SaleTerminal terminal = new SaleTerminal();

            terminal.SetPricing(products);
            terminal.SetPricing(product);

            terminal.Scan("ABCDABA");
            Console.WriteLine($"Total price: {terminal.CalculateTotal()}");

            terminal.Scan("CCCCCCC");
            Console.WriteLine($"Total price: {terminal.CalculateTotal()}");

            terminal.Scan("ABCD");
            Console.WriteLine($"Total price: {terminal.CalculateTotal()}");

            Console.ReadLine();
        }
    }
}