using AnimalPlanet.Core.Interfaces;
using AnimalsLib;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.ComponentModel;
using System.Windows.Data;

namespace AnimalPlanet.ViewModels
{
    internal class MainWindowViewModel:BindableBase
    {
        private string _title="Animal Planet";
        /// <summary>
        /// связующая модель между MainWindow и MainWindowViewModel
        /// </summary>
        private readonly IMainWindowModel _mainWindowModel;
        private DelegateCommand _squardChangedCommand;
        private DelegateCommand _editAnimalCommand;
        private DelegateCommand _addAnimalCommand;
        private DelegateCommand _deleteAnimalCommand;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IMainWindowModel mainWindowModel)
        {
            _mainWindowModel = mainWindowModel;
            _mainWindowModel.LoadData(SelectedSquard);
            _animalsViewSource = new CollectionViewSource();
            _animalsViewSource.Source = _mainWindowModel.Animals;
           
        }

        public ICollectionView AnimalsView => _animalsViewSource?.View;
        CollectionViewSource _animalsViewSource;

        private AnimalSquard _selectedSquard;
        public AnimalSquard SelectedSquard
        {
            get { return _selectedSquard; }
            set { SetProperty(ref _selectedSquard, value); }
        }

        private IAnimal _selectedAnimal;

        /// <summary>
        /// Выбранное животное
        /// </summary>
        public IAnimal SelectedAnimal
        {
            get { return _selectedAnimal; }
            set { SetProperty(ref _selectedAnimal, value); }
        }

        private SaveOptions _selectedSaveOption;
        /// <summary>
        /// Выбранный формат в который сохраняется данные
        /// </summary>
        public SaveOptions SelectedSaveOption
        {
            get { return _selectedSaveOption; }
            set { SetProperty(ref _selectedSaveOption, value); }
        }

        /// <summary>
        /// Выполняется при смене отображаемого отряда животных
        /// </summary>
        public DelegateCommand SquardChangedCommand =>
           _squardChangedCommand ??= _squardChangedCommand = new (() =>
           {               
               _mainWindowModel.LoadData(SelectedSquard);
           });

        

        public DelegateCommand EditAnimalCommand =>
           _editAnimalCommand ??= _editAnimalCommand = new(() =>
           {
               _mainWindowModel.EditAnimal(SelectedAnimal,SelectedSquard);
               RefreshView();             
           });

        

        public DelegateCommand AddAnimalCommand =>
            _addAnimalCommand ??=  _addAnimalCommand = new(() =>
            {
                _mainWindowModel.AddAnimal();               
            });


        public DelegateCommand DeleteAnimalCommand =>
           _deleteAnimalCommand ??= _deleteAnimalCommand = new(() =>
           {
               _mainWindowModel.Remove(SelectedAnimal);
               RefreshView();
           });

        private DelegateCommand _saveToFileCommand;

        public DelegateCommand SaveToFileCommand =>
           _saveToFileCommand ??= _saveToFileCommand = new(() =>
           {
               SaveFileDialog saveFileDialog = new();
               
               if(saveFileDialog.ShowDialog()==true)
               {
                   _mainWindowModel.SaveToFile(saveFileDialog.FileName,SelectedSaveOption);
               }
              
           });
      

        /// <summary>
        /// Обновляет представление
        /// </summary>
        public void RefreshView() =>
            _animalsViewSource.View.Refresh();




    }
}
