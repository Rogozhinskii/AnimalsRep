namespace AnimalsLib.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Объект отвечает за сохранения элементов хранилища в разных форматах
        /// </summary>
        ISaver SaveMode { get; set; }
        /// <summary>
        /// Хранимые элементы
        /// </summary>
        List<T> Items { get; set; }
        /// <summary>
        /// Добавляет объект в хранилище
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);
        /// <summary>
        /// Удаляет объект из хранилища
        /// </summary>
        /// <param name="item"></param>
        void Remove(T item);
        /// <summary>
        /// Сохраняет объекты хранилища по указанному пути
        /// </summary>
        /// <param name="savePath"></param>
        void SaveTo(string savePath);

        /// <summary>
        /// Выполняет принятие изменений в хранилище
        /// </summary>
        void Commit();

    }    
}
