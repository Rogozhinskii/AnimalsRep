namespace AnimalsLib.Interfaces
{
    public interface ISaver
    {
        /// <summary>
        /// Сохраняет коллекцию объектов по указанному пути
        /// </summary>
        /// <param name="savePath">путь сохранения</param>
        /// <param name="animals"> коллекция объектов для сохранения</param>
        void SaveData(string savePath,List<IAnimal> animals);
    }
}
