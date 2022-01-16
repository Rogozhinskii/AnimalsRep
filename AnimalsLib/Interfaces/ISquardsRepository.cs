using System.Collections.Generic;

namespace AnimalsLib.Interfaces
{
    public interface ISquardsRepository<T>
    {
        /// <summary>
        /// Хранит соответсвие отряда животных и их конкретных представителей
        /// </summary>
        Dictionary<AnimalSquard, List<T>> Squard { get; }

        /// <summary>
        /// Выполняет принятие изменений в хранилище
        /// </summary>
        public void Commit();
    }
}
