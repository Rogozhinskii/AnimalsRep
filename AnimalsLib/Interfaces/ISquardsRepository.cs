using System.Collections.Generic;

namespace AnimalsLib.Interfaces
{
    public interface ISquardsRepository<T>:IRepository<T>
    {
        Dictionary<AnimalSquard, List<T>> Squard { get; }
    }
}
