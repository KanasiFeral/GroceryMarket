namespace GroceryMarketConsoleUI
{
    public interface IRepositoryConfig
    {
        IList<T> Read<T>();
    }
}