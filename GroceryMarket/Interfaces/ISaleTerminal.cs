namespace GroceryMarket.Interfaces
{
    public interface ISaleTerminal
    {
        bool SetPricing();
        bool Scan(string productCode);
        double CalculateTotal();
    }
}