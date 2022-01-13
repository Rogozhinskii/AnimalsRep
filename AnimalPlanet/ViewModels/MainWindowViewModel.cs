using AnimalPlanet.Core.Interfaces;
using AnimalsLib;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace AnimalPlanet.ViewModels
{
    internal class MainWindowViewModel:BindableBase
    {
        private string _title="Animal Planet";
        private readonly IMainWindowModel _mainWindowModel;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ObservableCollection<IAnimal> Animals => _mainWindowModel.Animals;

        public MainWindowViewModel(IMainWindowModel mainWindowModel)
        {
            _mainWindowModel = mainWindowModel;
        }

    }
}
