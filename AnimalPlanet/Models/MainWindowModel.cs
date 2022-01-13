using AnimalPlanet.Core.Interfaces;
using AnimalsLib;
using AnimalsLib.Interfaces;
using System.Collections.ObjectModel;

namespace AnimalPlanet.Models
{
    internal class MainWindowModel : IMainWindowModel
    {
        private readonly IRepository _repository;

        public MainWindowModel(IRepository repository)
        {
            _repository = repository;
        }

        public ObservableCollection<IAnimal> Animals { get; set; } = new ObservableCollection<IAnimal>();

        public void UpdateData()
        {
            Animals.Clear();
            var newAnimals = _repository.Animals;
            Animals.AddRange(newAnimals);
        }
    }
}
