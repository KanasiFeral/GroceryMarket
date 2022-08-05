using System.Collections.Generic;
using GroceryMarket.Interfaces;

namespace GroceryMarket.Classes
{
    public class DBConfigReader : IRepositoryConfig
    {
        public IList<T> Read<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}