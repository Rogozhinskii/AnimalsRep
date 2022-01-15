using AnimalsLib;
using System.Collections.ObjectModel;

namespace AnimalPlanet.Core.Interfaces
{
    public interface IMainWindowModel
    {
        ObservableCollection<IAnimal> Animals { get; }

        void UpdateData();
        void UpdateData(AnimalSquard squard);
        void EditAnimal(IAnimal SelectedAnimal, AnimalSquard squard);
        public void AddAnimal();
        public void Remove(IAnimal animal);
        public void SaveToFile(string filePath,SaveOptions options);

    }
}
