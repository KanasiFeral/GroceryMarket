using System.Collections.Generic;

namespace ConsoleUI
{
    public interface IRepositoryConfig
    {
        IList<T> Read<T>();
    }
}