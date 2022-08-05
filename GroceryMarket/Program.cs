using GroceryMarket.Classes;
using System;

namespace GroceryMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SaleTerminal terminal = new SaleTerminal();

            terminal.SetPricing();

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