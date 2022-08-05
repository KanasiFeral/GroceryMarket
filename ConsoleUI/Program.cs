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
            List<ProductDto> products = new List<ProductDto>()
            {
                new ProductDto()
                {
                    ProductCode = "A",
                    Price = 1.25,
                    IsWholesale = true,
                    WholesalePrice = 3.00,
                    WholesaleCount = 3                    
                },
                new ProductDto()
                {
                    ProductCode = "B",
                    Price = 4.25,
                    IsWholesale = false,
                    WholesalePrice = 0.00,
                    WholesaleCount = 0                    
                },
                new ProductDto()
                {
                    ProductCode = "C",
                    Price = 1.00,
                    IsWholesale = true,
                    WholesalePrice = 5.00,
                    WholesaleCount = 6
                }
            };

            ProductDto product = new ProductDto()
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