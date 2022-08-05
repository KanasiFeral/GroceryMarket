using System.Collections.Generic;

namespace GroceryMarket.Interfaces
{
    public interface IRepositoryConfig
    {
        IList<T> Read<T>();
    }
}