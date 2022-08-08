using GroceryMarketAPI.Classes;
using GroceryMarketAPI.ModelsDTO;

List<ProductDto> products = new()
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

ProductDto product = new()
{
    ProductCode = "D",
    Price = 0.75,
    IsWholesale = false,
    WholesalePrice = 0.00,
    WholesaleCount = 0
};

SaleTerminal terminal = new();

terminal.SetPricing(product);
terminal.SetPricing(products);

terminal.Scan("ABCEDABA");
Console.WriteLine($"Total price: {terminal.CalculateTotal()}");

terminal.Scan("CCCCCCC");
Console.WriteLine($"Total price: {terminal.CalculateTotal()}");

terminal.Scan("ABCD");
Console.WriteLine($"Total price: {terminal.CalculateTotal()}");

Console.ReadLine();