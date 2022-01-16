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
    /// <summary>
    /// Главная модель приложения
    /// </summary>
    internal class MainWindowModel : IMainWindowModel
    {
        /// <summary>
        /// Хранилище животных
        /// </summary>
        private readonly IRepository<IAnimal> _repository;
        /// <summary>
        /// Фабрика для получения списка животных конкретного типа
        /// </summary>
        private readonly ISquardFactory _squardFactory;
        private readonly IDialogService _dialogService;

        public MainWindowModel(IRepository<IAnimal> repository, ISquardFactory squardFactory,IDialogService dialogService)
        {
            _repository = repository;
            _squardFactory = squardFactory;
            _dialogService = dialogService;
        }

        /// <summary>
        /// Коллекция загружаемых объектов
        /// </summary>
        public ObservableCollection<IAnimal> Animals { get; set; } = new ObservableCollection<IAnimal>();

        /// <summary>
        /// Загружает объекты из хранилища
        /// </summary>
        public void LoadData()
        {
            Animals.Clear();
            var newAnimals = _repository.Items;
            Animals.AddRange(newAnimals);
        }

        /// <summary>
        /// Загружает объекты из хранилища
        /// </summary>
        /// <param name="animalSquard">конкретный тип животного</param>
        public void LoadData(AnimalSquard animalSquard)
        {
            Animals.Clear();
            var newAnimals = _squardFactory.GetAnimalsBySquard(animalSquard);
            Animals.AddRange(newAnimals);
        }

        /// <summary>
        /// Вызывает окна редактирования животного 
        /// </summary>
        /// <param name="SelectedAnimal"></param>
        /// <param name="animalSquard"></param>
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

        /// <summary>
        /// Выполняет добавление животины в хранилище
        /// </summary>
        public void AddAnimal()
        {
            try
            {
                _dialogService.ShowDialog(CommonTypesPrism.AddDialog, null, r =>
                {
                    if (r.Result != ButtonResult.OK) return;
                    var newAnimal = r.Parameters.GetValue<IAnimal>(CommonTypesPrism.Editableobject);
                    _repository.Add(newAnimal);
                    LoadData(newAnimal.AnimalSquard);
                    ShowNotificationDialog(DialogType.NotificationDialog, "Добавлено новое животное");
                });
            }
            catch (Exception ex)
            {
                ShowNotificationDialog(DialogType.ErrorDialog, ex.Message);                
            }           
        }


        /// <summary>
        /// Удаляет животное из хранилища
        /// </summary>
        /// <param name="animal"></param>
        public void Remove(IAnimal animal)
        {
            try
            {
                _repository.Remove(animal);
                LoadData(animal.AnimalSquard);
                ShowNotificationDialog(DialogType.NotificationDialog, "Запись удалена");
            }
            catch (Exception ex)
            {
                ShowNotificationDialog(DialogType.ErrorDialog, ex.Message);                
            }
           
        }

        /// <summary>
        /// Вызывает окна уведомлений
        /// </summary>
        /// <param name="dialogType"></param>
        /// <param name="message"></param>
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
