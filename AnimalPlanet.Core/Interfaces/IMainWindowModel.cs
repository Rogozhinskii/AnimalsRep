using AnimalsLib;
using System.Collections.ObjectModel;

namespace AnimalPlanet.Core.Interfaces
{
    public interface IMainWindowModel
    {
        /// <summary>
        /// Коллекция объектов 
        /// </summary>
        ObservableCollection<IAnimal> Animals { get; }
        /// <summary>
        /// Выполняет загрузку всех записей из хранилища
        /// </summary>
        void LoadData();

        /// <summary>
        /// Выполняет загрузку записей, соответсвующей группы AnimalSquard,  из хранилища 
        /// </summary>
        /// <param name="squard">отряд п</param>
        void LoadData(AnimalSquard squard);

        /// <summary>
        /// Выполняет редактирование объекта
        /// </summary>
        /// <param name="SelectedAnimal"></param>
        /// <param name="squard"></param>
        void EditAnimal(IAnimal SelectedAnimal, AnimalSquard squard);

        /// <summary>
        /// Выполняет добавление нового объекта
        /// </summary>
        public void AddAnimal();

        /// <summary>
        /// Выполняет удаление объекта из хранилища
        /// </summary>
        /// <param name="animal"></param>
        public void Remove(IAnimal animal);

        /// <summary>
        /// Сохраняет объекты хранилища по указанному пути в соотсвующем формате
        /// </summary>
        /// <param name="filePath">путь сохранения</param>
        /// <param name="options">формат сохранения</param>
        public void SaveToFile(string filePath,SaveOptions options);

    }
}
