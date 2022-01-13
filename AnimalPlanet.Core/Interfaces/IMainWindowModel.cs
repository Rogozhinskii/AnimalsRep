using AnimalsLib;
using System.Collections.ObjectModel;

namespace AnimalPlanet.Core.Interfaces
{
    public interface IMainWindowModel
    {
        ObservableCollection<IAnimal> Animals { get; }

        void UpdateData();

    }
}
