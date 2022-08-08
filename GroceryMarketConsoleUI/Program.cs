using GroceryMarketAPI.Classes;
using GroceryMarketAPI.Mapper;
using GroceryMarketAPI.ModelsDTO;

List<ProductDto> products = new()
{
    new ProductDto()
    {
        ProductCode = "A",
        Price = 1.25
        
    },
    new ProductDto()
    {                    
        ProductCode = "B",                    
        Price = 4.25
    },                
    new ProductDto()                
    {                    
        ProductCode = "C",                    
        Price = 1.00 
    }            
};

List<DiscountDto> discounts = new()
{
    new DiscountDto()
    {
        ProductCode= "A",
        WholesalePrice = 3.00,
        WholesaleCount = 3
    },
    new DiscountDto()
    {
        ProductCode = "C",
        WholesalePrice = 5.00,
        WholesaleCount = 6
    }
};

ProductDto product = new()
{
    ProductCode = "D",
    Price = 0.75
};

SaleTerminal terminal = new(
    new OrderScan(), 
    new PriceCalculator(), 
    new ProductMapper(), 
    new DiscountMapper()
);

terminal.SetPricing(product, null);
terminal.SetPricing(products, discounts);

terminal.Scan("ABCEDABA");
Console.WriteLine($"Total price: {terminal.CalculateTotal()}");

terminal.Scan("CCCCCCC");
Console.WriteLine($"Total price: {terminal.CalculateTotal()}");

terminal.Scan("ABCD");
Console.WriteLine($"Total price: {terminal.CalculateTotal()}");

Console.ReadLine();