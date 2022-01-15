using AnimalPlanet.Core;
using AnimalPlanet.Core.Interfaces;
using AnimalsLib;
using AnimalsLib.Factories;
using AnimalsLib.Interfaces;
using AnimalsLib.Savers;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;

namespace AnimalPlanet.Models
{
    internal class MainWindowModel : IMainWindowModel
    {
        private readonly IRepository<IAnimal> _repository;
        private readonly ISquardFactory _squardFactory;
        private readonly IDialogService _dialogService;

        public MainWindowModel(IRepository<IAnimal> repository, ISquardFactory squardFactory,IDialogService dialogService)
        {
            _repository = repository;
            _squardFactory = squardFactory;
            _dialogService = dialogService;
        }

        public ObservableCollection<IAnimal> Animals { get; set; } = new ObservableCollection<IAnimal>();

        public void UpdateData()
        {
            Animals.Clear();
            var newAnimals = _repository.Items;
            Animals.AddRange(newAnimals);
        }

        public void UpdateData(AnimalSquard animalSquard)
        {
            Animals.Clear();
            var newAnimals = _squardFactory.GetAnimalsBySquard(animalSquard);
            Animals.AddRange(newAnimals);
        }

        public void EditAnimal(IAnimal SelectedAnimal, AnimalSquard animalSquard)
        {
            if (SelectedAnimal == null) return;
            var parameters = new DialogParameters();
            parameters.Add(CommonTypesPrism.Editableobject, SelectedAnimal);
            _dialogService.ShowDialog(CommonTypesPrism.EditDialog, parameters, r =>
             {
                 if (r.Result != ButtonResult.OK) return;
                
             });
        }

        public void AddAnimal()
        {
            try
            {
                _dialogService.ShowDialog(CommonTypesPrism.AddDialog, null, r =>
                {
                    if (r.Result != ButtonResult.OK) return;
                    var newAnimal = r.Parameters.GetValue<IAnimal>(CommonTypesPrism.Editableobject);
                    _repository.Add(newAnimal);
                    UpdateData(newAnimal.AnimalSquard);
                    ShowNotificationDialog(DialogType.NotificationDialog, "Добавлено новое животное");
                });
            }
            catch (Exception ex)
            {
                ShowNotificationDialog(DialogType.ErrorDialog, ex.Message);                
            }           
        }


        public void Remove(IAnimal animal)
        {
            try
            {
                _repository.Remove(animal);
                UpdateData(animal.AnimalSquard);
                ShowNotificationDialog(DialogType.NotificationDialog, "Запись удалена");
            }
            catch (Exception ex)
            {
                ShowNotificationDialog(DialogType.ErrorDialog, ex.Message);                
            }
           
        }

        public void ShowNotificationDialog(DialogType dialogType, string message)
        {
            var parameters = new DialogParameters
            {
                { CommonTypesPrism.DialogMessage, message }
            };

            switch (dialogType)
            {
                case DialogType.NotificationDialog:
                    _dialogService.Show(CommonTypesPrism.NotificationDialog, parameters, null);
                    break;
                case DialogType.ErrorDialog:
                    _dialogService.Show(CommonTypesPrism.ErrorNotification, parameters, null);
                    break;
                default:
                    _dialogService.Show(CommonTypesPrism.ErrorNotification, parameters, null);
                    break;
            }
        }

        public void SaveToFile(string filePath, SaveOptions options)
        {
            try
            {
                ISaver saver = options switch
                {
                    SaveOptions.SaveToTxt => new TxtSaver(),
                    SaveOptions.SaveToJson => new JsonSaver(),
                    SaveOptions.SaveToExcel => new XlsxSaver(),
                    _ => throw new InvalidOperationException("не ясен формат сохранения")
                };

                _repository.SaveMode = saver;
                _repository.SaveTo(filePath);
                ShowNotificationDialog(DialogType.NotificationDialog, "Файл сохранен");
            }
            catch (Exception ex)
            {
                ShowNotificationDialog(DialogType.ErrorDialog, ex.Message);                
            }
           
            
        }
    }
}
