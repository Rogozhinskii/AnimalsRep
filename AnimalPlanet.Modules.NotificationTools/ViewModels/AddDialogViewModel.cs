using AnimalPlanet.Core;
using AnimalPlanet.Modules.NotificationTools.ViewModels.Base;
using AnimalsLib;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;

namespace AnimalPlanet.Modules.NotificationTools.ViewModels
{
    /// <summary>
    /// вью модель для диалогового окна добавления объекта
    /// </summary>
    internal class AddDialogViewModel:DialogViewModel
    {
        /// <summary>
        /// Что-то что содержит фабричный метод создания объекта
        /// </summary>
        private readonly IAnimalFactory _animalFactory;
        private readonly IDialogService _dialogService;

        public string Name {get;set;}
        /// <summary>
        /// Семейство
        /// </summary>
        public string AnimalFamily { get; set; }
        /// <summary>
        /// Вид животного
        /// </summary>
        public string AnimalKind { get; set; }
        /// <summary>
        /// Отряд животного
        /// </summary>
        public AnimalSquard AnimalSquard { get; set; }
        public bool IsExtinct { get; set; }

        public AddDialogViewModel(IAnimalFactory animalFactory,IDialogService dialogService)
        {
            _animalFactory = animalFactory;
            _dialogService = dialogService;
        }

        private DelegateCommand _saveNewAnimalCommand;
        /// <summary>
        /// Выполняет сохранение изменений
        /// </summary>
        public DelegateCommand SaveNewAnimalCommand =>
           _saveNewAnimalCommand ??= _saveNewAnimalCommand = new(() =>
           {
               try
               {
                   var newAnimal = _animalFactory.GetAnimal(Name, AnimalFamily, AnimalKind, IsExtinct);
                   DialogResult result = new DialogResult(ButtonResult.OK);
                   result.Parameters.Add(CommonTypesPrism.Editableobject, newAnimal);
                   RaiseRequestClose(result);
               }
               catch(NullReferenceException ex)
               {
                   ShowNotificationDialog(DialogType.ErrorDialog, ex.Message);
               }
               catch (MemberAccessException ex)
               {
                   ShowNotificationDialog(DialogType.ErrorDialog, ex.Message);                   
               }
               catch(Exception ex)
               {
                   ShowNotificationDialog(DialogType.ErrorDialog, ex.Message);
               }
              
           });

        private DelegateCommand _cancelCommand;
        

        /// <summary>
        /// Отменяет изменения и закрывает диалоговое окно
        /// </summary>
        public DelegateCommand CancelCommand =>
           _cancelCommand ??= _cancelCommand = new(() =>
           {               
               var result = new DialogResult(ButtonResult.Cancel);
               RaiseRequestClose(result);
           });




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
    }
}
